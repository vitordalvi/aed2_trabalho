using System;
using System.Collections.Generic;
using System.Text;
using aed2_trabalho.Controllers;

namespace aed2_trabalho.View
{
    public class DisciplinasView
    {
        private readonly DisciplinasController _disciplinasController;

        public DisciplinasView(DisciplinasController disciplinasController)
        {
            _disciplinasController = disciplinasController;
        }
        public void SelecionarOpcao(string op)
        {
            switch (op)
            {
                case "1":
                    CadastroDisciplina();
                    break;

                case "2":
                    ConsultaAlunosDisciplina();
                    break;
            }
        }

        public void CadastroDisciplina()
        {
            Console.WriteLine("VOCÊ SOLICITOU A OPÇÃO DE CADASTRO: Cadastro da Disciplina");
        }

        public void ConsultaAlunosDisciplina()
        {
            Console.WriteLine("VOCÊ SOLICITOU A OPÇÃO DE CONSULTA: Consultar Alunos na Disciplina");
        }

    }
}

