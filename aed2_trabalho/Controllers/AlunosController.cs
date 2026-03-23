using aed2_trabalho.Services;

namespace aed2_trabalho.Controllers
{
    public class AlunosController
    {
        private readonly AlunosService _alunosService;
        public AlunosController(AlunosService alunosService)
        {
            _alunosService = alunosService;
        }

        // Controller para criar o Aluno
        public void CriarAluno(string nome, int idade)
        {
            _alunosService.CreateAluno(nome, idade);
        }
    }
}
