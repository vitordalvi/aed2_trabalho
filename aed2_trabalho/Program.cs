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

            string basePath = AppContext.BaseDirectory;
            string path = $"{basePath}/Data/db/Alunos.dat";
            //Alunos aluno = new Alunos("teste", 10);
            //Alunos aluno2 = new Alunos("teste3", 30);
            //File.AppendAllText(path, aluno.GetNome() + "\n");
            //File.AppendAllText(path, aluno2.GetNome() + "\n");
            
        }
    }
}
