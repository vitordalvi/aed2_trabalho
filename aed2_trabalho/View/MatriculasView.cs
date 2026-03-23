using System;
using System.Collections.Generic;
using System.Text;
using aed2_trabalho.Controllers;

namespace aed2_trabalho.View
{
    public class MatriculasView
    {
        private readonly MatriculasController _matriculasController;

        public MatriculasView(MatriculasController matriculasController)
        {
            _matriculasController = matriculasController;
        }

        public void SelecionarOpcao(string op)
        {
            switch (op)
            {
                case "1":
                    ConsultaMatricula();
                    break;

                case "2":
                    CadastroMatricula();
                    break;
            }
        }

        public void ConsultaMatricula()
        {
            Console.WriteLine("VOCÊ SOLICITOU A OPÇÃO DE CONSULTA: Consulta da Matrícula");
        }

        public void CadastroMatricula()
        {
            Console.WriteLine("VOCÊ SOLICITOU A OPÇÃO DE CADASTRO: Cadastro da Matrícula");
        }
    }
}
