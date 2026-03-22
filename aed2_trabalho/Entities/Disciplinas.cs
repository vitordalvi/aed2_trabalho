using aed2_trabalho.Entities;

namespace aed2_trabalho.entities
{
    public class Disciplinas : BaseEntity
    {
        // Unica
        private int CodigoDisciplina;
        private string NomeDisciplina;
        private double NotaMinima;

        int disciplinaInicial = 1;
        public Disciplinas(string nomeDisciplina, double notaMinima)
        {
            CodigoDisciplina += disciplinaInicial + 1;
            NomeDisciplina = nomeDisciplina;
            NotaMinima = notaMinima;

            disciplinaInicial++;
        }

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

        public void SetNomeDisciplina(string nome)
        {
            NomeDisciplina = nome;
        }

        public void SetNotaMinima(double notaMinima)
        {
            NotaMinima = notaMinima;
        }
    }
}
