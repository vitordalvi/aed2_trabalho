using aed2_trabalho.entities;
using aed2_trabalho.Entities;
using aed2_trabalho.Services;

namespace aed2_trabalho.Controllers
{
    public class DisciplinasController
    {
        private readonly DisciplinasService _disciplinasService;

        public DisciplinasController(DisciplinasService disciplinasService)
        {
            _disciplinasService = disciplinasService;
        }

        public Disciplinas[] CriarDisciplinas(string[] nomes, double[] notasMinimas)
        {
            var disciplinas = _disciplinasService.CreateDisciplinas(nomes, notasMinimas);

            if (disciplinas == null)
            {
                throw new Exception("Houve uma falha para criação das disciplinas.");
            }

            return disciplinas;
        }

        public Disciplinas[] ConsultarTodasDisciplinas()
        {
            return _disciplinasService.ConsultarTodasDisciplinas();
        }

        public bool SalvarDisciplinas(Disciplinas[] disciplinas)
        {
            return _disciplinasService.Save(disciplinas);
        }

        public void Continue(string op)
        {
            _disciplinasService.Continue(op);
        }
    }
}
