using aed2_trabalho.Data;

namespace aed2_trabalho.Repositories
{
    public class MatriculasRepository : IMatriculasRepository
    {
        private readonly DbService _dbContext;

        public MatriculasRepository(DbService dbContext)
        {
             _dbContext = dbContext;
        }
    }
}
