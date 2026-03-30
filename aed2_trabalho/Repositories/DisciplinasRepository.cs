using aed2_trabalho.Data;
using aed2_trabalho.entities;

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
            }

            // se deu errado, pega a exception
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            // retorna a exception
            throw new Exception("Disciplina não encontrada pelo código.");
        }

        // retorna todas as disciplinas
        public Disciplinas[] GetAllDisciplinas()
        {
            try
            {
                // le as linhas do arquivo
                string[] lines = File.ReadAllLines(_dbContext.dbPaths[2]);
                // salva um vetor de disciplinas com o tamanho = quantidade linhas do arquivo
                Disciplinas[] disciplinas = new Disciplinas[lines.Length];

                // passa por todas as linhas
                for (int i = 0; i < lines.Length; i++)
                {
                    // caso a linha do arquivo esteja vazia ou nula, retorna exception
                    if (string.IsNullOrEmpty(lines[i]))
                    {
                        throw new Exception($"O índice {i} do arquivo {_dbContext.dbPaths[2]} está vazio ou é nulo.");
                    }

                    // separa os dados da linha por ;
                    string[] data = lines[i].Split(';');

                    // para cada linha, cria um objeto na posição correta
                    for (int j = 0; j < data.Length; j++)
                    {
                        Disciplinas disciplina = new Disciplinas(int.Parse(data[0]), data[1], double.Parse(data[2]));
                        disciplinas[i] = disciplina;
                    }
                }

                // retorna o vetor das disciplinas já preenchido
                return disciplinas;
            }

            // se houve uma falha, retorna a exception para debuggar
            catch (Exception ex)
            {
                throw new Exception($"Falha ao consultar todas as disciplinas.");
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
