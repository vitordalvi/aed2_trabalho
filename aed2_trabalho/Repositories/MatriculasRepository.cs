using aed2_trabalho.Data;
using aed2_trabalho.entities;
using aed2_trabalho.Entities;

namespace aed2_trabalho.Repositories
{
    public class MatriculasRepository : IMatriculasRepository
    {
        private readonly DbService _dbContext;
        private readonly IAlunoRepository _alunosRepository;
        private readonly IDisciplinasRepository _disciplinasRepository;

        public MatriculasRepository(DbService dbContext, IAlunoRepository alunosRepository, IDisciplinasRepository disciplinasRepository)
        {
             _dbContext = dbContext;
            _alunosRepository = alunosRepository;
            _disciplinasRepository = disciplinasRepository;
        }

        //Ao selecionar Cadastro de Matrículas, deverá solicitar o Aluno e a Disciplina;	Deverá aceitar tanto o nome quanto a matrícula do aluno;
	    //Deverá aceitar tanto o nome quanto o código da disciplina;
	    //Caso o aluno ou a disciplina não existam, deverá exibir mensagem informando e solicitando novos dados;



        // 
        public Matriculas AddMatricula(Alunos aluno, Disciplinas disciplina)
        {
            
        }
    }
}
