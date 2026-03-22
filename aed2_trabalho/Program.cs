namespace aed2_trabalho
{
    using aed2_trabalho.Controllers;
    using aed2_trabalho.Data;
    using aed2_trabalho.Services;
    using aed2_trabalho.View;
    using aed2_trabalho.Entities;

    class Program
    {
        public static void Main(string[] args)
        {
            //ViewController.Iniciar();
            DatabaseInitializer.VerifyDatabase();
            DbService.InitializeData();
        }
    }
}
