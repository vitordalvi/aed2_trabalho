using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using aed2_trabalho.Controllers;
using aed2_trabalho.entities;
using aed2_trabalho.Entities;

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
                    ConsultarTodasDisciplinas();
                    break;
            }
        }

        public void CadastroDisciplina()
        {
            Console.WriteLine("\nVOCÊ SOLICITOU A OPÇÃO DE CADASTRO: Disciplinas\n");
            Console.Write("Insira a quantidade de disciplinas que deseja cadastrar: ");

            if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
            {
                Console.WriteLine("Quantidade inválida.");
                return;
            }

            string[] nomes = new string[quantidade];
            double[] notasMinimas = new double[quantidade];

            for (int i = 0; i < quantidade; i++)
            {
                Console.WriteLine($"\nDisciplina {i + 1}/{quantidade}");

                Console.Write("Nome: ");
                nomes[i] = Console.ReadLine();

                Console.Write("Nota mínimas: ");
                if (!double.TryParse(Console.ReadLine(), out notasMinimas[i]))
                {
                    Console.WriteLine("Idade inválida.");
                    i--;
                }
            }

            var disciplinasCriadas = _disciplinasController.CriarDisciplinas(nomes, notasMinimas);
            string op = SalvarDisciplinas();

            if (op == "s")
            {
                _disciplinasController.SalvarDisciplinas(disciplinasCriadas);
                Console.WriteLine($"\n{disciplinasCriadas.Length} disciplina(s) criada(s) com sucesso.");
            }
            else
            {
                Console.WriteLine("\nOperação cancelada, nenhum aluno salvo.");
            }

            string repeatOption = ExitOption();
            _disciplinasController.Continue(repeatOption);

        }

        public void ConsultarTodasDisciplinas()
        {
            Console.WriteLine("\nVOCÊ SOLICITOU A OPÇÃO DE CONSULTA: Disciplinas\n");

            var disciplinas = _disciplinasController.ConsultarTodasDisciplinas();

            for (int i = 0; i < disciplinas.Length; i++)
            {
                int cod = disciplinas[i].GetCodigoDisciplina();
                string nome = disciplinas[i].GetNomeDisciplina();
                double notaMinima = disciplinas[i].GetNotaMinima();

                Console.WriteLine($"Código: {cod}, Nome: {nome}, Nota Mínima: {notaMinima}.");
            }

            string repeatOption = ExitOption();
            _disciplinasController.Continue(repeatOption);
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
        public string SalvarDisciplinas()
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

