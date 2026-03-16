namespace aed2_trabalho.Services.View
{
    public class Inicio
    {
        public static string AoIniciar()
        {
            Console.WriteLine("CALCULAR RESULTADO DAS PROVAS DE ALUNOS - AEDII\n");
            Console.WriteLine("1 - Consultas (Alunos, Disciplinas, Alunos das Disciplinas, Disciplinas do Aluno)");
            Console.WriteLine("2 - Cadastros (Alunos, Disciplinas, Matrículas, Atribuir Nota e Aluno)");
            Console.WriteLine("3 - Salvar");
            Console.WriteLine("0 - Salvar e Sair");
            Console.Write("Selecione uma das opções:");
            string op = Console.ReadLine();

            return op;
        }

        public static void OpcaoSelecionada(string op)
        {
            if (op == null || op == "")
            {
                throw new FormatException("A opção escolhida não pode ser nula.");
            }

            if (!int.TryParse(op, out int val))
            {
                throw new FormatException("Você precisa selecionar um número válido: (0, 1, 2, 3)");
            }

            switch (val)
            {
                case 0:
                    // tem q implementar serviço pra sair?!
                    break;

                case 1:
                    // implementar serviço consulta
                    break;

                case 2:
                    // implementar serviço cadastro
                    break;

                case 3:
                    // implementar serviço salvar
                    break;
            }
        }
    }
}
