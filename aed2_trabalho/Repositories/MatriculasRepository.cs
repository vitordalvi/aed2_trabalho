using aed2_trabalho.Data;
using aed2_trabalho.entities;
using aed2_trabalho.Entities;
using System.Globalization;

namespace aed2_trabalho.Repositories
{
    public class MatriculasRepository : IMatriculasRepository
    {
        private readonly DbService _dbContext;
        private readonly IAlunoRepository _alunosRepository;
        private readonly IDisciplinasRepository _disciplinasRepository;

        public MatriculasRepository(DbService dbContext, IAlunoRepository alunosRepository, IDisciplinasRepository disciplinasRepository)
        {
            _dbContext = dbContext;
            _alunosRepository = alunosRepository;
            _disciplinasRepository = disciplinasRepository;
        }

        //Ao selecionar Cadastro de Matrículas, deverá solicitar o Aluno e a Disciplina;	Deverá aceitar tanto o nome quanto a matrícula do aluno;
        //Deverá aceitar tanto o nome quanto o código da disciplina;
        //Caso o aluno ou a disciplina não existam, deverá exibir mensagem informando e solicitando novos dados;


        // Repositorio para adicionar a matrícula, aqui só vai acontecer a adição mesmo, não a validação dos dados
        // tipo qual disciplina vai ser adicionada (descobrindo se vai ser pelo nome ou código) vai ser feita nos services
        // a mesma situação vai se repetir para adicionar o aluno à disciplina
        public Matriculas AddMatricula(Alunos aluno, Disciplinas disciplina)
        {
            try
            {
                // Se o número do indice for maior ou igual que o tamanho de matrículas (1000)
                if (_dbContext.NUMEROS_MATRICULAS >= _dbContext.matriculas.Length)
                {
                    // Retorna limite de matrículas, ai vai ter que criar um novo vetor com maior quantidade provavelmente (emoji_rindo_mt)
                    throw new Exception("Limite de matrículas atingido.");
                }

                // Adiciona a matrícula no índice correto 
                Matriculas novaMatricula = new Matriculas(_dbContext.TOTAL_MATRICULAS, aluno, disciplina);
                _dbContext.matriculas[_dbContext.NUMEROS_MATRICULAS] = novaMatricula;
                novaMatricula.SetMatriculaIndex(_dbContext.NUMEROS_MATRICULAS);

                // Aumenta o indice pra próxima matrícula q for criada
                _dbContext.TOTAL_MATRICULAS++;
                _dbContext.NUMEROS_MATRICULAS++;

                // Retorna o objeto da matríocula
                return novaMatricula;
            }

            // Se deu b.o até aqui, taca a exception pra tentar resolver no debug
            catch (Exception ex)
            {
                throw new Exception("Houve uma falha ao tentar adicionar a matrícula.", ex);
            }
        }

        public Matriculas[] GetAllMatriculas()
        {
            try
            {
                string[] lines = File.ReadAllLines(_dbContext.dbPaths[1]);
                Matriculas[] matriculas = new Matriculas[lines.Length];

                // função para poder usar pontos flutuantes com virgual (br) e ponto (padrao EN_US)
                static bool TryParseDoubleFlexible(string value, out double result)
                {
                    return double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out result)
                        || double.TryParse(value, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
                }

                // passa por todas as linhas do arquivo
                for (int i = 0; i < lines.Length; i++)
                {
                    // se algum indice for vazio, possivelmente pode dar um problema para a ordem
                    if (string.IsNullOrEmpty(lines[i]))
                    {
                        // entao retorna uma exception para resolução do problema, aí tem que ver pq ficou nulo mas acho que nao vai acontecer
                        throw new Exception($"O índice {i} do arquivo {_dbContext.dbPaths[1]} está vazio ou é nulo.");
                    }

                    // vetor para armazenar os dados separados por ;
                    string[] data = lines[i].Split(';');

                    if (data.Length != 5)
                    {
                        Console.WriteLine($"Linha de matrícula ignorada (índice {i}): esperado 5 colunas e encontrado {data.Length}.");
                        continue;
                    }

                    if (!int.TryParse(data[0], out int codigoMatricula) ||
                        !int.TryParse(data[1], out int matriculaAluno) ||
                        !int.TryParse(data[2], out int codigoDisciplina) ||
                        !TryParseDoubleFlexible(data[3], out double nota1) ||
                        !TryParseDoubleFlexible(data[4], out double nota2))
                    {
                        Console.WriteLine($"Linha de matrícula ignorada (índice {i}): '{lines[i]}'");
                        continue;
                    }

                    Matriculas matricula = new Matriculas(codigoMatricula, matriculaAluno, codigoDisciplina, nota1, nota2);
                    matricula.SetMatriculaIndex(i);
                    matriculas[i] = matricula;  
                }

                // retorna o vetor contendo todos as disciplinas
                return matriculas;
            }

            catch (Exception ex)
            {
                throw new Exception("Falha ao consultar todas as matrículas.", ex);
            }
        }



        // Salvar as matrículas no arquivo
        public bool Save(Matriculas matricula)
        {
            try
            {
                // pega o indice em que a matrícula está atualmente, na memória 
                int posLinha = matricula.GetMatriculaIndex();

                // pré definição da linha que será inserida
                // formato correto: codigoMatricula;matriculaAluno;codigoDisciplina;nota1;nota2
                string linha = $"{matricula.GetCodigoMatricula()};{matricula.GetMatriculaAluno()};{matricula.GetCodigoDisciplina()};{matricula.GetNota1().ToString(CultureInfo.InvariantCulture)};{matricula.GetNota2().ToString(CultureInfo.InvariantCulture)}";

                // leitura de todas as linhas do arquivo
                string[] lines = File.ReadAllLines(_dbContext.dbPaths[1]);

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
                File.WriteAllLines(_dbContext.dbPaths[1], lines);

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
