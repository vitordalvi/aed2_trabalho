using aed2_trabalho.Controllers;
using aed2_trabalho.View;

namespace aed2_trabalho.Services
{
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

        public void Iniciar()
        {
            while (true)
            {
                string op = _inicioView.Iniciar();

                switch (op)
                {
                    case "0":
                        Console.WriteLine("Salvar e Sair");
                        Environment.Exit(0);
                        break;

                    case "1":
                        Console.WriteLine("\nSelecione o item que será consultado:\n1 - Lista de Alunos\n2 - Disciplinas\n3 - Alunos das Disciplinas\n4 - Disciplinas do Aluno");
                        Console.Write("\nSelecione a opção: ");
                        SelecionarItemConsulta(Console.ReadLine());
                        break;

                    case "2":
                        Console.WriteLine("\nSelecione o item que será cadastrado:\n1 - Alunos\n2 - Disciplinas\n3 - Matrículas\n4 - Atribuir Nota a Aluno");
                        Console.Write("\nSelecione a opção: ");
                        SelecionarItemCadastro(Console.ReadLine());
                        break;

                    case "3":
                        Console.WriteLine("Salvar e Realizar outra Operação");
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente!\n");
                        break;
                }
            }
        }

        private void SelecionarItemConsulta(string op)
        {
            switch (op)
            {
                case "1":
                    _alunosView.ConsultarTodosAlunos();
                    break;
                case "2":
                    _disciplinasView.ConsultarTodasDisciplinas();
                    break;
                case "3":
                    _matriculasView.ConsultaAlunosDisciplina();
                    break;
                case "4":
                    _matriculasView.ConsultaDisciplinasAluno();
                    break;
                default:
                    Console.WriteLine("Opção de consulta inválida.");
                    break;
            }
        }

        private void SelecionarItemCadastro(string op)
        {
            switch (op)
            {
                case "1":
                    _alunosView.CadastroAlunos();
                    break;
                case "2":
                    _disciplinasView.CadastroDisciplina();
                    break;
                case "3":
                    _matriculasView.CadastroMatricula();
                    break;
                case "4":
                    _matriculasView.AtribuirNotaAluno();
                    break;
                default:
                    Console.WriteLine("Opção de cadastro inválida.");
                    break;
            }
        }
    }
}
