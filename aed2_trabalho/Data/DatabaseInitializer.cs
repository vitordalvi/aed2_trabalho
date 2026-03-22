using aed2_trabalho.Services;
using aed2_trabalho.Entities;
using aed2_trabalho.entities;

namespace aed2_trabalho.Data
{
    public class DatabaseInitializer
    {
        // Caminhos dos arquivos .dat
        static string basePath = AppContext.BaseDirectory;
        static string dbFolderPath = "Data/db";
        public static string[] dbPaths = new string[3]
        {
            $"{basePath}/Data/db/Alunos.dat",
            $"{basePath}/Data/db/Matriculas.dat",
            $"{basePath}/Data/db/Disciplinas.dat"
        };

        // Método para criar os diretórios
        public static void CreateDatabase()
        {
            // Se não estiver o folder "db/", vai criar
            if (!Directory.Exists(dbFolderPath))
            {
                Directory.CreateDirectory(dbFolderPath);
            }

            // Verificação de cada arquivo .dat
            for (int i = 0; i < dbPaths.Length; i++)
            {
                // Se existir o arquivo especifico, passa
                if (File.Exists(dbPaths[i]))
                {
                    continue;
                }

                // Nome da entidade que está faltando, já com a retirada da extensão do arquivo
                string missingEntity = Path.GetFileName(dbPaths[i]).Split('.')[0];

                // Se não existir, cria o arquivo que está faltando
                File.CreateText(dbPaths[i]);
            }
        }
        
        // Método para verificar se a base de dados está correta
        public static bool VerifyDatabase()
        {
            // Verificação de cada arquivo
            for (int i = 0; i < dbPaths.Length; i++)
            {
                // Se não existir, vai chamar a função criar os arquivos novamente (só vai criar o arquivo necessário)
                if (!File.Exists(dbPaths[i]))
                {
                    CreateDatabase();
                }
            }

            // Retorna true, porque vai criar o arquivo antes de sair
            return true;
        }
    }
}
