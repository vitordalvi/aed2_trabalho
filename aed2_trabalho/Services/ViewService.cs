using aed2_trabalho.View;

namespace aed2_trabalho.Services
{
    public class ViewService
    {
        // Input das opcoes
        public static string InputOpcoes()
        {
            InicioView.AoIniciar();
            string op = Console.ReadLine();
            return op;
        }

        // Verificar opcao selecionada
        public static void OpcaoSelecionada(string op)
        {
            switch (op)
            {
                case "0":
                    // implementar servico sair?
                    Console.WriteLine("Serviço sair e sair");
                    break;

                    case "1":
                    // implementar servico consulta
                    Console.WriteLine("serviço consulta");
                    break;

                    case "2":
                    // implementar servico cadastro
                    Console.WriteLine("serviço cadastro");
                    break;

                    case "3":
                    // implementar servico salvar
                    Console.WriteLine("servico salvar e realizar outra operacao");
                    break;

                    default:
                    Console.Write("Opção inválida. Tente novamente!\n\n");

                    string tentarNovamente = InputOpcoes();
                    OpcaoSelecionada(tentarNovamente);
                    break;

                }
            } 


        // Valida a opcao, retornando valor booleano
        public static bool ValidarOpcao(string op)
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
        public static int ConverterValorOpcao(string op)
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
        public static int GetOpcao(string op)
        {
            return ConverterValorOpcao(op);
        }
    }
}
