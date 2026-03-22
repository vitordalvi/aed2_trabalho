namespace aed2_trabalho.Entities
{
    public class Alunos
    {
        // Unica
        private int MatriculaAluno;
        private string Nome;
        private int Idade;

        int matriculaInicial = 0;
        public Alunos(string nome, int idade)
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
