using aed2_trabalho.Data;
using aed2_trabalho.entities;
using aed2_trabalho.Entities;

namespace aed2_trabalho.Repositories
{
    public class DisciplinasRepository : IDisciplinasRepository
    {
        private readonly DbService _dbContext;

        public DisciplinasRepository(DbService dbContext)
        {
            _dbContext = dbContext;
        }

        // Método para achar disciplina específica por codigo da disciplina (id)
        public Disciplinas GetDisciplinaById(int codigoDisciplina)
        {
            try
            {
                // lê todas as linhas do disciplinas.dat
                string[] lines = File.ReadAllLines(_dbContext.dbPaths[2]);

                // passa por cada linha arquivo
                for (int i = 0; i < lines.Length; i++)
                {
                    // armazena cada dado separado pelo ; em um vetor
                    string[] data = lines[i].Split(';');

                    // se a pos0 da data (codigo disciplina) for igual ao codigo da disciplina informada
                    if (data[0] == codigoDisciplina.ToString())
                    {
                        Disciplinas disciplina = new Disciplinas(int.Parse(data[0]), data[1], double.Parse(data[2]));

                        // retorna a disciplina e todos os dados dela
                        return disciplina;
                    }
                }
                return null;
            }

            // se deu errado, pega a exception
            catch
            {
                return null;
            }

        }

        // Método para adicionar disciplina
        public Disciplinas AddDisciplina(string nome, double notaMinima)
        {
            try
            {
                if (_dbContext.NUMEROS_DISCIPLINAS >= _dbContext.disciplinas.Length)
                {
                    throw new Exception("Limite de disciplinas atingido.");
                }

                Disciplinas novaDisciplina = new Disciplinas(_dbContext.TOTAL_DISCIPLINAS, nome, notaMinima);
                _dbContext.disciplinas[_dbContext.NUMEROS_DISCIPLINAS] = novaDisciplina;
                novaDisciplina.SetDisciplinaIndex(_dbContext.NUMEROS_DISCIPLINAS);

                // Aumenta os indices para toda disciplina criada
                _dbContext.TOTAL_DISCIPLINAS++;
                _dbContext.NUMEROS_DISCIPLINAS++;

                // Retorna o objeto da disciplina
                return novaDisciplina;
            }

            // Caso haja uma falha até aqui, retorna a exception para debug
            catch (Exception ex)
            {
                throw new Exception("Houve uma falha ao adicionar disciplina.");
            }
        }

        public Disciplinas[] GetAllDisciplinas()
        {
            try
            {
                string[] lines = File.ReadAllLines(_dbContext.dbPaths[2]);
                Disciplinas[] disciplinas = new Disciplinas[lines.Length];

                // passa por todas as linhas do arquivo
                for (int i = 0; i < lines.Length; i++)
                {
                    // se algum indice for vazio, possivelmente pode dar um problema para a ordem
                    if (string.IsNullOrEmpty(lines[i]))
                    {
                        // entao retorna uma exception para resolução do problema, aí tem que ver pq ficou nulo mas acho que nao vai acontecer
                        throw new Exception($"O índice {i} do arquivo {_dbContext.dbPaths[2]} está vazio ou é nulo.");
                    }

                    // vetor par armazenar os dados separados por ;
                    string[] data = lines[i].Split(';');

                    // cria um novo aluno de acordo com o tamanho do arquivo e posiciona os atributos na posição correta
                    for (int j = 0; j < data.Length; j++)
                    {
                        Disciplinas disciplina = new Disciplinas(int.Parse(data[0]), data[1], double.Parse(data[2]));
                        disciplinas[i] = disciplina;
                    }
                }

                // retorna o vetor contendo todos as disciplinas
                return disciplinas;
            }

            catch (Exception ex)
            {
                throw new Exception("Falha ao consultar todas as disciplinas.");
            }
        }

        public Disciplinas[] GetDisciplinasByName(string nome)
        {
            // Se o nome for vazio, retorna o vetor disciplinas vazio
            if (string.IsNullOrWhiteSpace(nome))
            {
                return new Disciplinas[0];
            }

            // retira espaços do final do nome
            string param = nome.Trim();

            // armazena as linhas do arquivo Disciplinas.dat em um vetor
            string[] lines = File.ReadAllLines(_dbContext.dbPaths[2]);

            // contagem inicial da quantidade de nomes (iguais)
            int count = 0;

            // percorre o vetor de linhas
            for (int i = 0; i < lines.Length; i++)
            {
                // se a linha na posicao i for vazia ou nula, continua, mas evitar erro de linhas "fantasmas"
                if (string.IsNullOrEmpty(lines[i]))
                {
                    continue;
                }

                // vetor para as colunas
                string[] data = lines[i].Split(';');

                // se o tamanho da coluna for menor q 3 (id(0), nome(1), idade(2)
                if (data.Length >= 3)
                {
                    // se a coluna 1 (nome) == nome.trim, compara ignorando letras maiusculas
                    if (string.Equals(data[1].Trim(), param, StringComparison.OrdinalIgnoreCase))
                    {
                        // aumenta a contagem (mesmos nomes encontrados)
                        count++;
                    }
                }
            }

            // cria o vetor de disciplinas com a quantidade de disciplinas que tem o nome igual
            Disciplinas[] encontrados = new Disciplinas[count];

            // anota o indice de disciplinas encontrados
            int index = 0;

            // percorre as linhas do arquivo 
            for (int i = 0; i < lines.Length; i++)
            {
                // se a linha for nula ou vazia, não atrapalha no for para contagem
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    continue;
                }

                // armazena as colunas separadas pelo ;
                string[] data = lines[i].Split(';');

                if (data.Length >= 3)
                {
                    // valida se o nome no arquivo.trim() é == nome(parametro).trim() e ignora letras maiusculas
                    // se data[0](matricula) for numero, retorna o cod como inteiro e o mesmo para nota minima
                    if (string.Equals(data[1].Trim(), param, StringComparison.OrdinalIgnoreCase) &&
                        int.TryParse(data[0], out int numeroDisciplina) && double.TryParse(data[2], out double notaMinima))
                    {
                        // objeto das disciplinas encontrados (mesmo nome) retorna como vetor de disciplinas
                        encontrados[index++] = new Disciplinas(numeroDisciplina, data[1].Trim(), notaMinima);
                    }
                }
            }

            return encontrados;
        }

        // Salvar as disciplinas no arquivo
        public bool Save(Disciplinas disciplina)
        {
            try
            {
                int posLinha = disciplina.GetDisciplinaIndex();
                string linha = $"{disciplina.GetCodigoDisciplina()};{disciplina.GetNomeDisciplina()};{disciplina.GetNotaMinima()}";

                string[] lines = File.ReadAllLines(_dbContext.dbPaths[2]);

                // checa se o vetor atual tem tamanho menor q o novo indice do aluno
                if (posLinha >= lines.Length)
                {
                    // cria a cópia do vetor das linhas, com +1 espaço
                    string[] newLines = new string[posLinha + 1];

                    // copia as linhas antigas pro novo vetor
                    for (int i = 0; i < lines.Length; i++)
                    {
                        newLines[i] = lines[i];
                    }

                    // preenche o espaço do vetor string vazia pra nao ter valor nulo
                    for (int i = lines.Length; i < newLines.Length; i++)
                    {
                        newLines[i] = string.Empty;
                    }

                    // atualiza o vetor antigo com o valor do novo vetor
                    lines = newLines;
                }

                // insere os dados no indice correto
                lines[posLinha] = linha;

                // escreve os dados do vetor com tamanho atualizado e no indice q estavam antes
                File.WriteAllLines(_dbContext.dbPaths[2], lines);

                // se der tudo certo, retorna true (salvou o arquivo)
                return true;
            }

            // se deu algum problema, retorna o problema, q vai ser debuggado
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
