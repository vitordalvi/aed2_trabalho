using aed2_trabalho.Entities;

namespace aed2_trabalho.entities
{
    public class Disciplinas
    {
        // Unica
        private int CodigoDisciplina;
        private string NomeDisciplina;
        private double NotaMinima;

        private int disciplinaIndex;

        // Construtor para criação de novos objetos, com ID automatico
        public Disciplinas(string nomeDisciplina, double notaMinima)
        {
            NomeDisciplina = nomeDisciplina;
            NotaMinima = notaMinima;
        }

        // Construtor para leitura no arquivo, com ID atribuido
        public Disciplinas(int codigoDisciplina, string nomeDisciplina, double notaMinima)
        {
            CodigoDisciplina = codigoDisciplina;
            NomeDisciplina = nomeDisciplina;
            NotaMinima = notaMinima;
        }

        // Construtor vazio para criação do vetor inicial
        public Disciplinas() { }

        public int GetCodigoDisciplina()
        {
            return CodigoDisciplina;
        }

        public string GetNomeDisciplina()
        {
            return NomeDisciplina; 
        }

        public double GetNotaMinima()
        {
            return NotaMinima;
        }

        public int GetDisciplinaIndex()
        {
            return disciplinaIndex;
        }

        public void SetNomeDisciplina(string nome)
        {
            NomeDisciplina = nome;
        }

        public void SetNotaMinima(double notaMinima)
        {
            NotaMinima = notaMinima;
        }

        public void SetDisciplinaIndex(int disciplinaIndex)
        {
            this.disciplinaIndex = disciplinaIndex;
        }
    }
}
