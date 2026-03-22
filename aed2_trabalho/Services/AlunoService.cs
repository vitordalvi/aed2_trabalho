using aed2_trabalho.Repositories;

namespace aed2_trabalho.Services
{
    public class AlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public void CreateAluno(string nome, int idade)
        {
            _alunoRepository.CreateAluno(nome, idade);
        }

    }
}
