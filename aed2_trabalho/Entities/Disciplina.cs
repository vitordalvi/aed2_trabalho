namespace aed2_trabalho.entities
{
    class Disciplina
    {
        // Unica
        private int CodigoDisciplina;
        private string NomeDisciplina;
        private double NotaMinima;

        int disciplinaInicial = 1;
        public Disciplina(string nomeDisciplina, double notaMinima)
        {
            CodigoDisciplina += disciplinaInicial + 1;
            NomeDisciplina = nomeDisciplina;
            NotaMinima = notaMinima;

            disciplinaInicial++;
        }

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
