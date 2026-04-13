using aed2_trabalho.Entities;

namespace aed2_trabalho.entities
{
    public class Matriculas
    {
        // Unico
        private int CodigoMatricula;
        // Unico
        private int CodigoDisciplina;
        // Unico
        private int MatriculaAluno;

        private double Nota1;
        private double Nota2;

        private int matriculaIndex;

        // Construtor criado para leitura do arquivo
        public Matriculas(int codigoMatricula, int matriculaAluno, int codigoDisciplina, double nota1, double nota2)
        {
            CodigoMatricula = codigoMatricula;
            CodigoDisciplina = codigoDisciplina; 
            MatriculaAluno = matriculaAluno;
            Nota1 = nota1;
            Nota2 = nota2;
        }

        public Matriculas(int codigoDisciplina, int matriculaAluno)
        {
            CodigoDisciplina = codigoDisciplina;
            MatriculaAluno = matriculaAluno;
            Nota1 = 0.0;
            Nota2 = 0.0;
        }

        // Construtor para criação de novas matrículas
        public Matriculas(int codigoMatricula, Alunos aluno, Disciplinas disciplina)
        {
            CodigoMatricula = codigoMatricula;
            CodigoDisciplina = disciplina.GetCodigoDisciplina();
            MatriculaAluno = aluno.GetMatriculaAluno();
            Nota1 = 0.0;
            Nota2 = 0.0;
        }
        public Matriculas(int codigoDisciplina, int matriculaAluno, double nota1, double nota2)
        {
            CodigoDisciplina = codigoDisciplina;
            MatriculaAluno = matriculaAluno;
            Nota1 = nota1;
            Nota2 = nota2;
        }

        public Matriculas() { }


        public int GetCodigoMatricula()
        {
            return CodigoMatricula;
        }

        public void SetCodigoMatricula(int codigoMatricula)
        {
            CodigoMatricula = codigoMatricula;
        }
        public int GetCodigoDisciplina()
        {
            return CodigoDisciplina;
        }

        public int GetMatriculaAluno()
        {
            return MatriculaAluno;
        }

        public double GetNota1()
        {
            return Nota1;
        }

        public double GetNota2()
        {
            return Nota2;
        }

        public void SetNota1(double nota1)
        {
            Nota1 = nota1;
        }

        public void SetNota2(double nota2)
        {
            Nota2 = nota2;
        }

        public int GetMatriculaIndex()
        {
            return matriculaIndex;
        }

        public void SetMatriculaIndex(int matriculaIndex)
        {
            this.matriculaIndex = matriculaIndex; 
        }
    }
}
