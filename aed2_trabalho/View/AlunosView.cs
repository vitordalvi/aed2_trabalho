using aed2_trabalho.Controllers;

namespace aed2_trabalho.View
{
    public class AlunosView
    {
        private readonly AlunosController _alunosController;
        public AlunosView(AlunosController alunosController)
        {
            _alunosController = alunosController;
        }

        public void SelecionarOpcao(string op)
        {
            switch (op)
            {
                case "1":
                    CadastroAluno();
                    break;

                case "2":
                    ConsultaAluno();
                    break;

                case "3":
                    ConsultarDisciplinasAluno();
                    break;

                case "4":
                    AtribuirNotaAluno();
                    break;
            }
        }

        public void CadastroAluno()
        {
            Console.WriteLine("\nVOCÊ SOLICITOU A OPÇÃO DE CADASTRO: Alunos\n");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Idade: ");
            int idade = int.Parse(Console.ReadLine());

            _alunosController.CriarAluno(nome, idade);
        }

        public void AtribuirNotaAluno()
        {
            Console.WriteLine("\nVOCÊ SOLICITOU A OPÇÃO DE CADASTRO: Atribuir Nota ao Aluno\n");
        }

        public void ConsultaAluno()
        {
            Console.WriteLine("\nVOCÊ SOLICITOU A OPÇÃO DE CONSULTA: Alunos\n");
        }

        public void ConsultarDisciplinasAluno()
        {
            Console.WriteLine("\nVOCÊ SOLICITOU A OPÇÃO DE CONSULTA: Disciplinas do Aluno\n");
            
        }
    }
}
