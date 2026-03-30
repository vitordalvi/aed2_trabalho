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

        public Disciplinas GetDisciplinaById(int codigoDisciplina)
        {
            try
            {
                string[] lines = File.ReadAllLines(_dbContext.dbPaths[2]);

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] data = lines[i].Split(';');

                    if (data[0] == codigoDisciplina.ToString())
                    {
                        Disciplinas disciplina = new Disciplinas(int.Parse(data[0]), data[1], int.Parse(data[2]));

                        return disciplina;
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            throw new Exception("Disciplina não encontrada pelo código.");
        }
    }
}
