namespace aed2_trabalho.entities
{
    public class Matriculas
    {
        // Unico
        private int CodigoDisciplina;
        // Unico
        private int MatriculaAluno;

        private double Nota1;
        private double Nota2;

        public Matriculas(int codigoDisciplina, int matriculaAluno, double nota1, double nota2)
        {
            CodigoDisciplina = codigoDisciplina; 
            MatriculaAluno = matriculaAluno;
            Nota1 = nota1;
            Nota2 = nota2;
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
    }
}
