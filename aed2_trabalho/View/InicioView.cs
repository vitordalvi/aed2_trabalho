namespace aed2_trabalho.View
{
    public class InicioView
    {
        public string Iniciar()
        {
            Console.WriteLine("CALCULAR RESULTADO DAS PROVAS DE ALUNOS - AEDII\n");
            Console.WriteLine("1 - Consultas (Alunos, Disciplinas, Alunos das Disciplinas, Disciplinas do Aluno)");
            Console.WriteLine("2 - Cadastros (Alunos, Disciplinas, Matrículas, Atribuir Nota a Aluno)");
            Console.WriteLine("3 - Salvar e Realizar outra Operação");
            Console.WriteLine("0 - Salvar e Sair");
            Console.Write("Selecione uma das opções: ");

            return Console.ReadLine();
        }

        public string Salvar()
        {
            while (true)
            {
                Console.Write("Insira (S) para salvar alterações e (N) para ignorar: ");
                string op = Console.ReadLine().ToLowerInvariant();

                if (op == null)
                {
                    Console.Write("O valor não pode ser vazio, tente novamente: ");
                }

                if (op == "s" || op == "n")
                {
                    return op;
                }

                Console.Write("Insira uma opção válida: (S) ou (N): ");
            }

        }
    }
}
