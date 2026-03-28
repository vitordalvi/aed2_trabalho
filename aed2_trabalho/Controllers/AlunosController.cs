using aed2_trabalho.Entities;
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
        public Alunos[] CriarAlunos(string[] nomes, int[] idades)
        {
            return _alunosService.CreateAlunos(nomes, idades);
        }
    }
}
