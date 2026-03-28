using aed2_trabalho.Entities;
using aed2_trabalho.Services;
using aed2_trabalho.View;

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
            var alunos = _alunosService.CreateAlunos(nomes, idades);

            if (alunos == null)
            {
                throw new Exception("Houve uma falha para criação dos alunos.");
            }

            return alunos; 
        }

        public Alunos[] ConsultarTodosAlunos()
        {
            return _alunosService.ConsultarTodosAlunos();
        }

        public bool SalvarAlunos(Alunos[] alunos)
        {
            return _alunosService.Save(alunos);
        }

        public void Continue(string op)
        {
            _alunosService.Continue(op);
        }
    }
}
