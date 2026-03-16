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

        public static void Iniciar()
        {
            string op = ViewService.InputOpcoes();
            ViewService.OpcaoSelecionada(op);
        }
    }
}
