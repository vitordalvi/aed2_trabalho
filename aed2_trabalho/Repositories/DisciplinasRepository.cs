using aed2_trabalho.Data;

namespace aed2_trabalho.Repositories
{
    public class DisciplinasRepository : IDisciplinasRepository
    {
        private readonly DbService _dbContext;

        public DisciplinasRepository(DbService dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
