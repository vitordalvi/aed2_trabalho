using aed2_trabalho.Data;
using aed2_trabalho.Entities;

namespace aed2_trabalho.Repositories
{
    class AlunoRepository : IAlunoRepository
    {
        private readonly DbService _dbContext;
        public AlunoRepository(DbService dbContext)
        {
            _dbContext = dbContext;
        }

        // Achar o aluno pela matrícula
        public Alunos GetAlunoByMatricula(int matricula)
        {
            try
            {
                // Lê todas as linhas do arquivo Alunos.dat
                string[] lines = File.ReadAllLines(_dbContext.dbPaths[0]);

                // Passa por todas as linhas
                for (int i = 0; i < lines.Length; i++)
                {
                    // Separa os dados da linha em um vetor
                    string[] data = lines[i].Split(';');

                    // Data[0] == Matricula, converte para string
                    if (data[0] == matricula.ToString())
                    {
                        // Retorna o objeto aluno com os dados da linha 
                        Alunos aluno = new Alunos(int.Parse(data[0]), data[1], int.Parse(data[2]));
                        return aluno;
                    }
                }
                // Caso deu problema na validação, retorna a exception
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            // Não conseguiu achar um aluno, por algum problema, da a exception pra eu debuggar
            throw new Exception("Aluno não encontrado por matrícula.");
        }

        // Método para adicionar aluno
        public bool AddAluno(string nome, int idade)
        {
            try
            {
                // Se o número do indice for maior ou igual que o tamanho de alunos (1000)
                if (_dbContext.NUMEROS_ALUNOS >= _dbContext.alunos.Length)
                {
                    // Retorna limite de alunos, ai vai ter que criar um novo vetor com maior quantidade provavelmente (emoji_rindo_mt)
                    throw new Exception("Limite de alunos atingido.");
                }

                // Adiciona o aluno no índice correto 
                Alunos novoAluno = new Alunos(nome, idade);
                _dbContext.alunos[_dbContext.NUMEROS_ALUNOS] = novoAluno;

                // Cria a linha usando o indice de ref
                string linha = $"{novoAluno.GetMatriculaAluno()};{novoAluno.GetNome()};{novoAluno.GetIdade()}";

                // Salva a linha no arquivo dos alunos
                File.AppendAllText(_dbContext.dbPaths[0], linha + Environment.NewLine);

                // Aumenta o indice pro proximo aluno q for criado
                _dbContext.NUMEROS_ALUNOS++;

                // Retorna pro repositorio
                return true;
            }

            // Se deu b.o até aqui, taca a exception pra tentar resolver no debug
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        // Método para remover um aluno
        public bool DeleteAluno(int matricula)
        {
            Alunos aluno = GetAlunoByMatricula(matricula);

            try
            {
                string[] lines = File.ReadAllLines(_dbContext.dbPaths[0]);

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] data = lines[i].Split(';');

                    for (int j = 0; j < lines[i].Length; j++)
                    {
                        if (data[0] == aluno.GetMatriculaAluno().ToString())
                        {
                            for (int k = 0; k < lines[i].Length; k++)
                            {
                                lines[k].Replace(data[k], "");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }
        
    }
}
