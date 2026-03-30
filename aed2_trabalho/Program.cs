namespace aed2_trabalho
{
    using aed2_trabalho.Controllers;
    using aed2_trabalho.Data;
    using aed2_trabalho.Services;
    using aed2_trabalho.View;
    using aed2_trabalho.Entities;
    using aed2_trabalho.Repositories;

    class Program
    {
        public static void Main(string[] args)
        {
            // Banco de dados
            DatabaseInitializer.VerifyDatabase();
            DbService dbContext = new DbService();
            dbContext.LoadData();

            // Repositorios
            IAlunoRepository alunosRepository = new AlunoRepository(dbContext);
            IDisciplinasRepository disciplinasRepository = new DisciplinasRepository(dbContext);
            IMatriculasRepository matriculasRepository = new MatriculasRepository(dbContext, alunosRepository);

            // Services
            AlunosService alunosService = new AlunosService(alunosRepository);
            DisciplinasService disciplinasService = new DisciplinasService(disciplinasRepository);
            MatriculasService matriculasService = new MatriculasService(matriculasRepository);

            // Controllers
            AlunosController alunosController = new AlunosController(alunosService);
            DisciplinasController disciplinasController = new DisciplinasController(disciplinasService);
            MatriculasController matriculasController = new MatriculasController(matriculasService);

            // Views
            AlunosView alunosView = new AlunosView(alunosController);
            DisciplinasView disciplinasView = new DisciplinasView(disciplinasController);
            MatriculasView matriculasView = new MatriculasView(matriculasController);
            InicioView inicioView = new InicioView();
            

            // Controle geral Views
            ViewService viewService = new ViewService(inicioView, alunosView, disciplinasView, matriculasView);
            ViewController viewController = new ViewController(viewService);

            // Iniciar sistema
            viewController.Iniciar();
        }
    }
}
