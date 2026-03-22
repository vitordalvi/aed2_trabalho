using aed2_trabalho.entities;

namespace aed2_trabalho.Repositories
{
    public interface IAlunoRepository
    {
        public void CreateAluno(string nome, int idade);
    }
}
