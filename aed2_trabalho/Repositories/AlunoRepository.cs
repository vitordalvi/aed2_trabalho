using aed2_trabalho.Data;
using aed2_trabalho.Entities;

namespace aed2_trabalho.Repositories
{
    class AlunoRepository : IAlunoRepository
    {
        private readonly DbService _dbService;
        public AlunoRepository(DbService dbService)
        {
            _dbService = dbService;
        }
        public void CreateAluno(string nome, int idade)
        {
            Alunos aluno = new Alunos(nome, idade);
            bool success = DbService.AddAluno(aluno);

            if (!success)
            {
                throw new Exception("Falha ao adicionar aluno.");
            }

        }

        
    }
}
