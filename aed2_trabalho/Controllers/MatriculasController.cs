using aed2_trabalho.entities;
using aed2_trabalho.Entities;
using aed2_trabalho.Services;

namespace aed2_trabalho.Controllers
{
    public class MatriculasController
    {
        private readonly MatriculasService _matriculasService;

        public MatriculasController(MatriculasService matriculasService)
        {
            _matriculasService = matriculasService;
        }

        public Matriculas[] CriarMatriculas(string[] dadosAlunos, string[] dadosDisciplinas)
        {
            var matriculas = _matriculasService.CreateMatriculas(dadosAlunos, dadosDisciplinas);

            if (matriculas == null)
            {
                throw new Exception("Houve uma falha na criação das matrículas");
            }

            return matriculas;
        }

        public void ConsultarAlunosDisciplina(string[] data)
        {
            _matriculasService.ConsultarAlunosDisciplina(data);
        }

        public void Continue(string op)
        {
            _matriculasService.Continue(op);
        }
        public bool SalvarMatriculas(Matriculas[] matriculas)
        {
            return _matriculasService.Save(matriculas);
        }

        public void AtribuirNotaAluno(string dadoAluno, string dadoDisciplina, double nota1, double nota2)
        {
            _matriculasService.AtribuirNotaAluno(dadoAluno, dadoDisciplina, nota1, nota2);
        }

        public void ConsultarDisciplinasAluno(string[] data)
        {
            _matriculasService.ConsultarDisciplinasAluno(data);
        }
    }
}
