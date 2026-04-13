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
                    CadastroAlunos();
                    break;

                case "2":
                    ConsultarTodosAlunos();
                    break;

                case "3":
                    ConsultarDisciplinasAluno();
                    break;

                case "4":
                    AtribuirNotaAluno();
                    break;
            }
        }

        // Ver se consigo adaptar todas as validações no ViewServices (se der tempo, se não, deixar aqui mesmo)
        public void CadastroAlunos()
        {
            Console.WriteLine("\nVOCÊ SOLICITOU A OPÇÃO DE CADASTRO: Alunos\n");
            Console.Write("Insira a quantidade de alunos que deseja cadastrar: ");

            if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
            {
                Console.WriteLine("Quantidade inválida.");
                return;
            }

            string[] nomes = new string[quantidade];
            int[] idades = new int[quantidade];

            for (int i = 0; i < quantidade; i++)
            {
                Console.WriteLine($"\nAluno {i + 1}/{quantidade}");

                Console.Write("Nome: ");
                nomes[i] = Console.ReadLine();

                Console.Write("Idade: ");
                if (!int.TryParse(Console.ReadLine(), out idades[i]))
                {
                    Console.WriteLine("Idade inválida.");
                    i--;
                }
            }

            var alunosCriados = _alunosController.CriarAlunos(nomes, idades);
            string op = SalvarAlunos();

            if (op == "s")
            {
                _alunosController.SalvarAlunos(alunosCriados);
                Console.WriteLine($"\n{alunosCriados.Length} aluno(s) criado(s) com sucesso.");
            }
            else
            {
                Console.WriteLine("\nOperação cancelada, nenhum aluno salvo.");
            }

            string repeatOption = ExitOption();
            _alunosController.Continue(repeatOption);

        }

        public void ConsultarTodosAlunos()
        {
            Console.WriteLine("\nVOCÊ SOLICITOU A OPÇÃO DE CONSULTA: Alunos\n");

            var alunos = _alunosController.ConsultarTodosAlunos();

            for (int i = 0; i < alunos.Length; i++)
            {
                int matricula = alunos[i].GetMatriculaAluno();
                string nome = alunos[i].GetNome();
                int idade = alunos[i].GetIdade();

                Console.WriteLine($"Matrícula: {matricula}, Nome: {nome}, Idade: {idade}.");
            }

            string repeatOption = ExitOption();
            _alunosController.Continue(repeatOption);
        }

        public void AtribuirNotaAluno()
        {
            Console.WriteLine("\nVOCÊ SOLICITOU A OPÇÃO DE CADASTRO: Atribuir Nota ao Aluno\n");
        }

        public void ConsultarDisciplinasAluno()
        {
            Console.WriteLine("\nVOCÊ SOLICITOU A OPÇÃO DE CONSULTA: Disciplinas do Aluno\n");
        }

        public string ExitOption()
        {
            while (true)
            {
                Console.Write("\nVocê realizar outras operações? (S) ou (N): ");
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

        public string SalvarAlunos()
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
