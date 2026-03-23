namespace aed2_trabalho.Controllers
{
    using Services;
    public class ViewController
    {
        private readonly ViewService _viewService;

        public ViewController(ViewService viewService)
        {
            _viewService = viewService;
        }

        // GET INICIO
        public void Iniciar()
        {
            _viewService.Iniciar();
        }
    }
}
