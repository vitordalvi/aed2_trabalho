using aed2_trabalho.Data;
using aed2_trabalho.Entities;

namespace aed2_trabalho.Repositories
{
    public class AlunoRepository : IAlunoRepository
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
                        //aluno.SetAlunoIndex(i);

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
        public Alunos AddAluno(string nome, int idade)
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
                Alunos novoAluno = new Alunos(_dbContext.TOTAL_ALUNOS, nome, idade);
                _dbContext.alunos[_dbContext.NUMEROS_ALUNOS] = novoAluno;
                novoAluno.SetAlunoIndex(_dbContext.NUMEROS_ALUNOS);

                // Aumenta o indice pro proximo aluno q for criado
                _dbContext.TOTAL_ALUNOS++;
                _dbContext.NUMEROS_ALUNOS++;

                // Retorna pro repositorio
                return novoAluno;
            }

            // Se deu b.o até aqui, taca a exception pra tentar resolver no debug
            catch (Exception ex)
            {
                throw new Exception("Houve uma falha ao tentar adicionar o aluno.");
            }
        }

        // Método para remover um aluno
        // Arrumar o método, acho que está incorreto
        // TEM QUE COLOCAR A SUBTRAÇÃO DO NUMERO DE ALUNOS PARA CONSEGUIR CRIAR NO INDICE CERTO AS PROXIMAS OPERACOES
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

        public bool Save(Alunos aluno)
        {
            try
            {
                int posLinha = aluno.GetAlunoIndex();
                string linha = $"{aluno.GetMatriculaAluno()};{aluno.GetNome()};{aluno.GetIdade()}";

                string[] lines = File.ReadAllLines(_dbContext.dbPaths[0]);

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
                File.WriteAllLines(_dbContext.dbPaths[0], lines);

                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

    }
}
