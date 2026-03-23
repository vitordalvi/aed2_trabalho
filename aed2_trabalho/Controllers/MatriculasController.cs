using aed2_trabalho.Services;

namespace aed2_trabalho.Controllers
{
    public class MatriculasController
    {
        private readonly MatriculasService _matriculasService;

        public MatriculasController(MatriculasService matriculasService)
        {
            _matriculasService = matriculasService;
        }
    }
}
