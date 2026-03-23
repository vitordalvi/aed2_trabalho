using aed2_trabalho.entities;
using aed2_trabalho.Entities;

namespace aed2_trabalho.Data
{
    public class DbService : DatabaseInitializer
    {
        // Valor inicial entidades
        public static int NUMEROS_ALUNOS = 0;
        public static int NUMEROS_DISCIPLINAS = 0;
        public static int NUMEROS_MATRICULAS = 0;

        // Criação dos vetores que conterão os objetos
        public static Alunos[] alunos = new Alunos[1000];
        public static Disciplinas[] disciplinas = new Disciplinas[1000];
        public static Matriculas[] matriculas = new Matriculas[1000];

        public static void LoadData()
        {
            for (int i = 0; i < dbPaths.Length; i++)
            {
                string[] lines = File.ReadAllLines(dbPaths[i]);
                for (int j = 0; j < lines.Length; j++)
                {
                    string[] data = lines[j].Split(';');
                    switch (dbPaths[i].Split('.')[0])
                    {
                        case "Alunos":
                            Alunos aluno = new Alunos(int.Parse(data[0]), data[1], int.Parse(data[2]));
                            alunos[NUMEROS_ALUNOS] = aluno;
                            NUMEROS_ALUNOS++;
                            break;

                        case "Disciplinas":
                            Disciplinas disciplina = new Disciplinas(int.Parse(data[0]), data[1], double.Parse(data[2]));
                            disciplinas[NUMEROS_DISCIPLINAS] = disciplina;
                            NUMEROS_DISCIPLINAS++;
                            break;

                        case "Matriculas":
                            Matriculas matricula = new Matriculas(int.Parse(data[0]), int.Parse(data[1]), double.Parse(data[2]), double.Parse(data[3]));
                            matriculas[NUMEROS_MATRICULAS] = matricula;
                            NUMEROS_MATRICULAS++;
                            break;
                    }
                }
            }
        }

        public static bool AddAluno(Alunos aluno)
        {
            try
            {
                if (NUMEROS_ALUNOS >= alunos.Length)
                {
                    throw new Exception("Limite de alunos atingido.");
                }

                alunos[NUMEROS_ALUNOS] = aluno;
                NUMEROS_ALUNOS++;

                string linha = $"{aluno.GetMatriculaAluno()};{aluno.GetNome()};{aluno.GetIdade()}";
                File.AppendAllText(dbPaths[0], linha + Environment.NewLine);

                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public static bool AddMatricula(Matriculas matricula)
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
        public static bool AddDisciplina(Disciplinas disciplina)
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
