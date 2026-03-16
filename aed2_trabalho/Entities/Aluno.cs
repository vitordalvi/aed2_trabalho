namespace aed2_trabalho.entities
{
    public class Aluno
    {
        // Unica
        private int MatriculaAluno;
        private string Nome;
        private int Idade;


        int matriculaInicial = 0;
        public Aluno(string nome, int idade)
        {
            MatriculaAluno += matriculaInicial + 1;
            Nome = nome;
            Idade = idade;

            matriculaInicial++;
        }

        public int GetMatriculaAluno()
        {
            return MatriculaAluno;
        }

        public string GetNome()
        {
            return Nome;
        }

        public int GetIdade()
        {
            return Idade;
        }

        public void SetNome(string nome)
        {
            Nome = nome;
        }

        public void SetIdade(int idade)
        {
            Idade = idade;
        }
    }
}
