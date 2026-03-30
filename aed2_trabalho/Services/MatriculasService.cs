using aed2_trabalho.entities;
using aed2_trabalho.Repositories;

namespace aed2_trabalho.Services
{
    public class MatriculasService
    {
        private readonly IMatriculasRepository _matriculasRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IDisciplinasRepository _disciplinaRepository;
        public MatriculasService(
            IMatriculasRepository matriculasRepository,
            IAlunoRepository alunoRepository,
            IDisciplinasRepository disciplinaRepository)
        {
            _matriculasRepository = matriculasRepository;
            _alunoRepository = alunoRepository;
            _disciplinaRepository = disciplinaRepository;
        }


        // Vai ter que pegar os parametros como string para se o parametro for id, ele retornar o id como string e achar aqui
        // caso seja nome, ja vai estar como string, entao vai dar pra achar independente da informação (Eu acho)
        public Matriculas[] CreateMatriculas(string[] infoAluno, string[] infoDisciplina)
        {
            if (infoAluno == null || infoDisciplina == null)
                throw new ArgumentException("Vetores não podem ser nulos.");

            if (infoAluno.Length == 0 || infoDisciplina.Length == 0)
                throw new ArgumentException("Vetores não podem estar vazios.");

            Matriculas[] matriculasCriadas = new Matriculas[infoAluno.Length];

            for (int i = 0; i < infoAluno.Length; i++)
            {
                if (string.IsNullOrEmpty(infoAluno[i]))
                    throw new ArgumentException($"Informação inválida na posição {i}");

                if (string.IsNullOrEmpty(infoDisciplina[i]))
                    throw new ArgumentException($"Informação inválida na posição {i}");

                

                
            }
        }
    }
}
