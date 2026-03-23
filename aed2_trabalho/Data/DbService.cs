using aed2_trabalho.entities;
using aed2_trabalho.Entities;

namespace aed2_trabalho.Data
{
    public class DbService
    {
        // Valor inicial entidades
        public int NUMEROS_ALUNOS = 0;
        public int NUMEROS_DISCIPLINAS = 0;
        public int NUMEROS_MATRICULAS = 0;

        // Criação dos vetores que conterão os objetos
        public Alunos[] alunos = new Alunos[1000];
        public Disciplinas[] disciplinas = new Disciplinas[1000];
        public Matriculas[] matriculas = new Matriculas[1000];

        // Caminhos da BD
        public static string basePath = AppContext.BaseDirectory;
        public string dbFolderPath = "Data/db";
        public string[] dbPaths = new string[3]
        {
            $"{basePath}/Data/db/Alunos.dat",
            $"{basePath}/Data/db/Matriculas.dat",
            $"{basePath}/Data/db/Disciplinas.dat"
        };

        // Método para carregar todos os dados dos arquivos
        public void LoadData()
        {
            // Passa por todo o arquivo
            for (int i = 0; i < dbPaths.Length; i++)
            {
                // Lê todas as linhas do arquivo
                string[] lines = File.ReadAllLines(dbPaths[i]);

                // Passa por cada linha
                for (int j = 0; j < lines.Length; j++)
                {
                    // Separa os dados da linha em um vetor
                    string[] data = lines[j].Split(';');
                    
                    // Faz a separação da leitura de acordo com o tipo do arquivo, para criar os objetos certinho
                    switch (dbPaths[i].Split('.')[0])
                    {
                        // Se for alunos, cria o objeto do aluno
                        case "Alunos":
                            Alunos aluno = new Alunos(int.Parse(data[0]), data[1], int.Parse(data[2]));
                            // Alunos na posição da variável do indice, é setado naquela posição
                            alunos[NUMEROS_ALUNOS] = aluno;
                            // Aumento no número do índice
                            NUMEROS_ALUNOS++;
                            break;

                            // Mesma lógica
                        case "Disciplinas":
                            Disciplinas disciplina = new Disciplinas(int.Parse(data[0]), data[1], double.Parse(data[2]));
                            disciplinas[NUMEROS_DISCIPLINAS] = disciplina;
                            NUMEROS_DISCIPLINAS++;
                            break;

                            // Mesma lógica
                        case "Matriculas":
                            Matriculas matricula = new Matriculas(int.Parse(data[0]), int.Parse(data[1]), double.Parse(data[2]), double.Parse(data[3]));
                            matriculas[NUMEROS_MATRICULAS] = matricula;
                            NUMEROS_MATRICULAS++;
                            break;
                    }
                }
            }
        }



        public bool AddMatricula(Matriculas matricula)
        {
            try
            {
                if (NUMEROS_MATRICULAS >= matriculas.Length)
                {
                    throw new Exception("Limite de matrículas atingido.");
                }
                matriculas[NUMEROS_MATRICULAS] = matricula;
                NUMEROS_MATRICULAS++;
                string linha = $"{matricula.GetMatriculaAluno()};{matricula.GetCodigoDisciplina()}" +
                    $";{matricula.GetNota1()};{matricula.GetNota2()}";
                File.AppendAllText(dbPaths[2], linha + Environment.NewLine);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public bool AddDisciplina(Disciplinas disciplina)
        {
            try
            {
                if (NUMEROS_DISCIPLINAS >= disciplinas.Length)
                {
                    throw new Exception("Limite de disciplinas atingido.");
                }

                disciplinas[NUMEROS_DISCIPLINAS] = disciplina;
                NUMEROS_DISCIPLINAS++;

                string linha = $"{disciplina.GetCodigoDisciplina()};{disciplina.GetNomeDisciplina()};{
                    disciplina.GetNotaMinima()}";
                File.AppendAllText(dbPaths[3], linha + Environment.NewLine);

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
