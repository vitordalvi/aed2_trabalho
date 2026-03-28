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
            else if (idade <= 0)
            {
                throw new ArgumentException("A idade do Aluno não pode ser igual ou menor à zero.");
            }

            var aluno = _alunoRepository.AddAluno(nome, idade);

            if (aluno == null)
            {
                throw new Exception("Falha para criação do aluno.");
            }

            var save = _alunoRepository.Save(aluno);

            if (save != false)
            {
                Console.WriteLine($"Aluno: ID: {aluno.GetMatriculaAluno()}, Nome: {aluno.GetNome()}, Idade: {aluno.GetIdade()}");
            }
            
        }


    }
}
