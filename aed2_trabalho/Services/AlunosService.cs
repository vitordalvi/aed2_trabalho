using aed2_trabalho.Repositories;

namespace aed2_trabalho.Services
{
    public class AlunosService
    {
        private readonly IAlunoRepository _alunoRepository;
        public AlunosService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public void CreateAluno(string nome, int idade)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome não pode ser nulo.");
            }

            if (idade <= 0)
            {
                throw new ArgumentException("A idade do Aluno não pode ser igual ou menor à zero.");
            }

            var success = _alunoRepository.AddAluno(nome, idade);

            if (!success)
            {
                throw new Exception("Falha ao adicionar o aluno no banco de dados.");
            }
        }


    }
}
