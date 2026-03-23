namespace aed2_trabalho.Entities
{
    public class Alunos
    {
        // Unica
        private int MatriculaAluno;
        private string Nome;
        private int Idade;

        int matriculaInicial = 0;

        // Construtor utilizado para criação de um objeto aluno, atribuindo automaticamente o ID
        public Alunos(string nome, int idade)
        {
            MatriculaAluno += matriculaInicial + 1;
            Nome = nome;
            Idade = idade;

            matriculaInicial++;
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

        public override string ToString()
        {
            return $"{MatriculaAluno}; {Nome}; {Idade}"; 
        }
    }
}
