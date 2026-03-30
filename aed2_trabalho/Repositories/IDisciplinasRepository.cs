using aed2_trabalho.entities;
using aed2_trabalho.Entities;

namespace aed2_trabalho.Repositories
{
    public interface IDisciplinasRepository
    {
        public Disciplinas GetDisciplinaById(int codigoDisciplina);
        public Disciplinas[] GetAllDisciplinas();
        public Disciplinas AddDisciplina(string nome, double notaMinima);
        public bool Save(Disciplinas disciplina);
    }
}
