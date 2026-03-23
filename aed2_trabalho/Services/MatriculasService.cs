using aed2_trabalho.Repositories;

namespace aed2_trabalho.Services
{
    public class MatriculasService
    {
        private readonly IMatriculasRepository _matriculasRepository;
        public MatriculasService(IMatriculasRepository matriculasRepository)
        {
            _matriculasRepository = matriculasRepository;
        }
    }
}
