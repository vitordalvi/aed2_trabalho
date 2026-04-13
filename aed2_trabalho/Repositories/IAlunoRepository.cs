using aed2_trabalho.entities;
using aed2_trabalho.Entities;

namespace aed2_trabalho.Repositories
{
    public interface IAlunoRepository
    {
        public Alunos AddAluno(string nome, int idade);
        //public bool DeleteAluno(int matricula);
        public Alunos GetAlunoByMatricula(int matricula);
        public Alunos[] GetAlunosByName(string nome);
        public Alunos[] GetAllAlunos();
        public bool Save(Alunos aluno);
    }
}
