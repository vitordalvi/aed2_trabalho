using aed2_trabalho.entities;
using aed2_trabalho.Entities;

namespace aed2_trabalho.Data
{
    public class DbService : DatabaseInitializer
    {
        // Valor inicial entidades
        public int NUMEROS_ALUNOS = 0;
        public int NUMEROS_DISCIPLINAS = 0;
        public int NUMEROS_MATRICULAS = 0;
        public static void InitializeData()
        {
            // Criação dos vetores que conterão os objetos
            Alunos[] alunos = new Alunos[1000];
            Disciplinas[] disciplinas = new Disciplinas[1000];
            Matriculas[] matriculas = new Matriculas[1000];
        }

        public static bool AddAluno(Alunos aluno)
        {
            try
            {
                File.AppendText(dbPaths[0]);
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return true;
        }
    }
}
