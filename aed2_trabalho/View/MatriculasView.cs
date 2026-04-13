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
                    ConsultaAlunosDisciplina();
                    break;

                case "2":
                    CadastroMatricula();
                    break;

                case "3":
                    ConsultaDisciplinasAluno();
                    break;
            }
        }

        public void CadastroMatricula()
        {
            Console.WriteLine("\nVOCÊ SOLICITOU A OPÇÃO DE CADASTRO: Matrículas\n");
            Console.Write("Insira a quantidade de matrículas que deseja cadastrar: ");

            if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
            {
                Console.WriteLine("Quantidade inválida.");
                return;
            }

            string[] dadosAlunos = new string[quantidade];
            string[] dadosDisciplinas = new string[quantidade];

            for (int i = 0; i <  quantidade; i++)
            {
                Console.WriteLine($"\nMatrícula {i + 1}/{quantidade}");

                Console.Write($"Dado do aluno: ");
                dadosAlunos[i] = Console.ReadLine();

                Console.Write($"Dado da disciplina: ");
                dadosDisciplinas[i] = Console.ReadLine();
            }

            var matriculasCriadas = _matriculasController.CriarMatriculas(dadosAlunos, dadosDisciplinas);

            string op = SalvarMatriculas();

            if (op == "s")
            {
                _matriculasController.SalvarMatriculas(matriculasCriadas);
                Console.WriteLine($"\n{matriculasCriadas.Length} matrícula(s) criada(s) com sucesso.");
            }
            else
            {
                Console.WriteLine("\nOperação cancelada, nenhuma matrícula salvo.");
            }

            string repeatOption = ExitOption();
            _matriculasController.Continue(repeatOption);
        }

        // Ao selecionar Consulta de Alunos das Disciplinas, deverá listar todos os alunos da disciplina informada, listando as notas e se o aluno está aprovado ou reprovado;
        // Deverá aceitar tanto o nome quanto o código da disciplina;
        // Caso a disciplina não exista, deverá exibir mensagem indicando que a disciplina não existe e solicitando nova disciplina;
        // Aprovado: média da disciplina maior ou igual à Nota Mínima da disciplina;
        // Reprovado: média da disciplina menor que a Nota Mínima da disciplina;
        public void ConsultaAlunosDisciplina()
        {
            Console.WriteLine("\nVOCÊ SOLICITOU A OPÇÃO DE CONSULTA: Alunos das Disciplinas\n");

            Console.Write("Insira a quantidade de consultas que deseja fazer: ");
            if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
            {
                Console.WriteLine("Quantidade inválida.");
                return;
            }

            string[] dadosDisciplina = new string[quantidade];

            for (int i = 0; i < quantidade; i++)
            {
                Console.WriteLine($"\nDisciplina {i + 1}/{quantidade}");
                Console.Write("Dados da disciplina (nome ou código): ");
                dadosDisciplina[i] = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(dadosDisciplina[i]))
                {
                    Console.Write("Valor inválido. Informe novamente: ");
                    dadosDisciplina[i] = Console.ReadLine();
                }
            }

            try
            {
                _matriculasController.ConsultarAlunosDisciplina(dadosDisciplina);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro na consulta: {ex.Message}");
            }

            string repeatOption = ExitOption();
            _matriculasController.Continue(repeatOption);
        }

        public void ConsultaDisciplinasAluno()
        {
            Console.WriteLine("\nVOCÊ SOLICITOU A OPÇÃO DE CONSULTA: Disciplinas do Aluno\n");

            Console.Write("Insira a quantidade de consultas que deseja fazer: ");
            if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
            {
                Console.WriteLine("Quantidade inválida.");
                return;
            }

            string[] dadosAlunos = new string[quantidade];

            for (int i = 0; i < quantidade; i++)
            {
                Console.WriteLine($"\nAluno {i + 1}/{quantidade}");
                Console.Write("Dados do aluno (nome ou matrícula): ");
                dadosAlunos[i] = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(dadosAlunos[i]))
                {
                    Console.Write("Valor inválido. Informe novamente: ");
                    dadosAlunos[i] = Console.ReadLine();
                }
            }

            try
            {
                _matriculasController.ConsultarDisciplinasAluno(dadosAlunos);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro na consulta: {ex.Message}");
            }

            string repeatOption = ExitOption();
            _matriculasController.Continue(repeatOption);
        }

        public void AtribuirNotaAluno()
        {
            Console.WriteLine("\nVOCÊ SOLICITOU A OPÇÃO DE CADASTRO: Atribuir Nota ao Aluno\n");

            Console.Write("Dado do aluno (nome ou matrícula): ");
            string dadoAluno = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(dadoAluno))
            {
                Console.Write("Valor inválido. Informe novamente: ");
                dadoAluno = Console.ReadLine();
            }

            Console.Write("Dado da disciplina (nome ou código): ");
            string dadoDisciplina = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(dadoDisciplina))
            {
                Console.Write("Valor inválido. Informe novamente: ");
                dadoDisciplina = Console.ReadLine();
            }

            double nota1 = LerNota("Informe a Nota 1: ");
            double nota2 = LerNota("Informe a Nota 2: ");

            try
            {
                _matriculasController.AtribuirNotaAluno(dadoAluno, dadoDisciplina, nota1, nota2);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro ao atribuir nota: {ex.Message}");
            }

            string repeatOption = ExitOption();
            _matriculasController.Continue(repeatOption);
        }

        private double LerNota(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                string valor = Console.ReadLine();

                if (double.TryParse(valor, out double nota) && nota >= 0)
                    return nota;

                Console.WriteLine("Nota inválida.");
            }
        }

        public void Continue(string op)
        {
            if (op == "n")
            {
                Console.WriteLine("\nFinalizando o sistema...\n");
                Environment.Exit(0);
            }
            else if (op == "s")
            {
                Console.WriteLine("\nVoltando para o menu inicial...\n");
            }
        }

        public string SalvarMatriculas()
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
    }
}
