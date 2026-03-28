using aed2_trabalho.Controllers;
using aed2_trabalho.View;

namespace aed2_trabalho.Services
{
    // refatorar serviço com funcoes para cada escolha, dps integrar com opcoes de outras views como deseja salvar x entidade (arruamr uma forma de colocar todas em 1)
    public class ViewService
    {
        private readonly InicioView _inicioView;
        private readonly AlunosView _alunosView;
        private readonly DisciplinasView _disciplinasView;
        private readonly MatriculasView _matriculasView;

        public ViewService(InicioView inicioView, AlunosView alunosView, DisciplinasView disciplinasView, MatriculasView matriculasView)
        {
            _inicioView = inicioView;
            _alunosView = alunosView;
            _disciplinasView = disciplinasView;
            _matriculasView = matriculasView;
        }

        // Input das opcoes
        public void Iniciar()
        {
            string op = _inicioView.Iniciar();

            switch (op)
            {
                case "0":
                    // implementar servico sair?
                    Console.WriteLine("Salvar e Sair");
                    break;

                case "1":
                    // implementar servico consulta
                    Console.WriteLine("\nSelecione o item que será consultado:\n1 - Alunos\n2 - Disciplinas\n3 - Alunos das Disciplinas\n4 - Disciplinas do Aluno)");
                    Console.Write("\nSelecione a opção: ");
                    SelecionarItem(Console.ReadLine());
                    break;

                case "2":
                    // implementar servico cadastro
                    Console.WriteLine("\nSelecione o item que será cadastrado:\n1 - Alunos\n2 - Disciplinas\n3 - Matrículas\n4 - Atribuir Nota a Aluno");
                    Console.Write("\nSelecione a opção: ");
                    SelecionarItem(Console.ReadLine());
                    break;

                case "3":
                    // implementar servico salvar
                    Console.WriteLine("Salvar e Realizar outra Operação");
                    break;

                default:
                    Console.Write("Opção inválida. Tente novamente!\n\n");

                    op = _inicioView.Iniciar();
                    break;

            }
        }    
        
        public void SelecionarItem(string op)
        {
            if (op == null)
            {
                throw new Exception("Item inválido.");
            }

            switch (op)
            {
                case "1":
                    _alunosView.SelecionarOpcao(op);
                    break;

                case "2":
                    _disciplinasView.SelecionarOpcao(op);
                    break;

                case "3":
                    _matriculasView.SelecionarOpcao(op);
                    break;

                case "4":
                    _alunosView.SelecionarOpcao(op);
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;

            }

        }


        // Valida a opcao, retornando valor booleano
        public bool ValidarOpcao(string op)
        {
            // Opcoes disponiveis
            string[] ops = new string[] { "0", "1", "2", "3" };

            // Opcoes disponiveis como inteiros
            //int[] opsConvertidas = new int[ops.Length];

            // Se op for nulo ou vazio, retorna falso direto
            if (op == null || op == "")
            {
                return false;
            }

            // Verifica se eh um valor inteiro, retornando o valor como int val
            if (!int.TryParse(op, out int val))
            {
                // Retorna falso se nao for valor inteiro
                return false;
            }

            // Loop no array das opcoes disponiveis
            for (int i = 0; i < ops.Length; i++)
            {
                // Se op nao estiver nas opcoes (como string)
                if (!ops.Contains(op))
                {
                    // Ja retorna false
                    return false;
                }
            }

            return true;
        }

        // Converte o valor
        public int ConverterValorOpcao(string op)
        {
            // Se for invalido, retorna exception
            if (ValidarOpcao(op) == false)
            {
                throw new Exception("A opção inserida está incorreta.");
            }

            // Se for true, retorna o valor como inteiro
            return int.Parse(op);
        }

        // Retorna a opção como inteiro
        public int GetOpcao(string op)
        {
            return ConverterValorOpcao(op);
        }
    }
}
