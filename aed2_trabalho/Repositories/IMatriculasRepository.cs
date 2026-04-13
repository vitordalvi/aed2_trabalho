using aed2_trabalho.entities;
using aed2_trabalho.Entities;

namespace aed2_trabalho.Repositories
{
    public interface IMatriculasRepository
    {
        public Matriculas AddMatricula(Alunos aluno, Disciplinas disciplina);
        public Matriculas[] GetAllMatriculas();
        public bool Save(Matriculas matricula);
    }
}
