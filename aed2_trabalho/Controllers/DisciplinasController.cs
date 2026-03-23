using aed2_trabalho.Services;

namespace aed2_trabalho.Controllers
{
    public class DisciplinasController
    {
        private readonly DisciplinasService _disciplinasService;

        public DisciplinasController(DisciplinasService disciplinasService)
        {
            _disciplinasService = disciplinasService;
        }

    }
}
