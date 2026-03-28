namespace aed2_trabalho.Entities
{
    public class Alunos
    {
        // Unica
        private int MatriculaAluno;
        private string Nome;
        private int Idade;

        private int alunoIndex;

        // Construtor utilizado para criação, a matrícula não é atribuida automaticamente
        public Alunos(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }

        // Caso utilizado somente para leitura do arquivo
        public Alunos(int matriculaAluno, string nome, int idade)
        {
            MatriculaAluno = matriculaAluno;
            Nome = nome;
            Idade = idade;
        }

        // Construtro para criação do objeto para o vetor de alunos
        public Alunos() { }

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

        public void SetAlunoIndex(int alunoIndex)
        {
            this.alunoIndex = alunoIndex;
        }
        public int GetAlunoIndex()
        {
            return alunoIndex;
        }

        public override string ToString()
        {
            return $"{MatriculaAluno}; {Nome}; {Idade}"; 
        }
    }
}
