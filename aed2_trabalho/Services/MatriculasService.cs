using aed2_trabalho.entities;
using aed2_trabalho.Entities;
using aed2_trabalho.Repositories;

namespace aed2_trabalho.Services
{
    public class MatriculasService
    {
        private readonly IMatriculasRepository _matriculasRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IDisciplinasRepository _disciplinaRepository;
        public MatriculasService(
            IMatriculasRepository matriculasRepository,
            IAlunoRepository alunoRepository,
            IDisciplinasRepository disciplinaRepository)
        {
            _matriculasRepository = matriculasRepository;
            _alunoRepository = alunoRepository;
            _disciplinaRepository = disciplinaRepository;
        }


        // Vai ter que pegar os parametros como string para se o parametro for id, ele retornar o id como string e achar aqui
        // caso seja nome, ja vai estar como string, entao vai dar pra achar independente da informação (Eu acho)
        public Matriculas[] CreateMatriculas(string[] infoAluno, string[] infoDisciplina)
        {
            if (infoAluno == null || infoDisciplina == null)
                throw new ArgumentException("Vetores não podem ser nulos.");

            if (infoAluno.Length == 0 || infoDisciplina.Length == 0)
                throw new ArgumentException("Vetores não podem estar vazios.");

            Matriculas[] matriculasCriadas = new Matriculas[infoAluno.Length];

            for (int i = 0; i < infoAluno.Length; i++)
            {
                if (string.IsNullOrEmpty(infoAluno[i]))
                    throw new ArgumentException($"Informação inválida na posição {i}");

                if (string.IsNullOrEmpty(infoDisciplina[i]))
                    throw new ArgumentException($"Informação inválida na posição {i}");


                var aluno = ResolverAlunos(infoAluno[i]);
                var disciplina = ResolverDisciplinas(infoDisciplina[i]);

                while (aluno == null || disciplina == null)
                {
                    if (aluno == null)
                    {
                        Console.Write("\nO aluno não foi encontrado. Tente com outros dados: ");
                        string data = Console.ReadLine();
                        aluno = ResolverAlunos(data);
                    }

                    if (disciplina == null)
                    {
                        Console.Write("\nA disciplina não foi encontrada. Tente com outros dados: ");
                        string data = Console.ReadLine();
                        disciplina = ResolverDisciplinas(data);
                    }
                }

                matriculasCriadas[i] = _matriculasRepository.AddMatricula(aluno, disciplina);
            }

            return matriculasCriadas;
        }

        public void ConsultarAlunosDisciplina(string[] data)
        {
            if (data == null || data.Length == 0)
            {
                throw new ArgumentException("Os dados enviados não podem ser nulos ou vazios.");
            }

            Matriculas[] todasMatriculas = _matriculasRepository.GetAllMatriculas();

            if (todasMatriculas == null || todasMatriculas.Length == 0)
            {
                Console.WriteLine("\nNão existem matrículas cadastradas.");
                return;
            }

            for (int i = 0; i < data.Length; i++)
            {
                Disciplinas disciplina = ResolverDisciplinas(data[i]);

                int codigoDisciplina = disciplina.GetCodigoDisciplina();
                double notaMinima = disciplina.GetNotaMinima();

                Console.WriteLine($"\nDisciplina: {disciplina.GetNomeDisciplina()} (Código: {codigoDisciplina})");
                Console.WriteLine($"Nota mínima: {notaMinima}");

                int qtd = 0;

                for (int j = 0; j < todasMatriculas.Length; j++)
                {
                    Matriculas matriculas = todasMatriculas[j];

                    if (matriculas == null || matriculas.GetCodigoDisciplina() != codigoDisciplina)
                    {
                        continue;
                    }

                    qtd++;

                    Alunos aluno = _alunoRepository.GetAlunoByMatricula(matriculas.GetMatriculaAluno());

                    string nomeAluno = aluno.GetNome();
                    double nota1 = matriculas.GetNota1();
                    double nota2 = matriculas.GetNota2();
                    double media = (nota1 + nota2) / 2.0;

                    string status;

                    if (media >= notaMinima)
                    {
                        status = "Aprovado";
                    }
                    else
                    {
                        status = "Reprovado";
                    }

                    Console.WriteLine($"ID {matriculas.GetCodigoMatricula()} - Matrícula do Aluno: {matriculas.GetMatriculaAluno()} | Nome: {nomeAluno} | Nota 1: {nota1} | Nota 2: {nota2} | Média {media} | {status}");
                }

                if (qtd == 0)
                {
                    Console.WriteLine("Nenhum aluno vinculado à disciplina.");
                }

            }
        }

        public void ConsultarDisciplinasAluno(string[] data)
        {
            if (data == null || data.Length == 0)
            {
                throw new ArgumentException("Os dados enviados não podem ser nulos ou vazios.");
            }

            Matriculas[] todasMatriculas = _matriculasRepository.GetAllMatriculas();

            if (todasMatriculas == null || todasMatriculas.Length == 0)
            {
                Console.WriteLine("\nNão existem matrículas cadastradas.");
                return;
            }

            for (int i = 0; i < data.Length; i++)
            {
                Alunos aluno = ResolverAlunos(data[i]);
                int matriculaAluno = aluno.GetMatriculaAluno();

                Console.WriteLine($"\nAluno: {aluno.GetNome()} (Matrícula: {matriculaAluno})");

                int qtd = 0;

                for (int j = 0; j < todasMatriculas.Length; j++)
                {
                    Matriculas matricula = todasMatriculas[j];

                    if (matricula == null || matricula.GetMatriculaAluno() != matriculaAluno)
                    {
                        continue;
                    }

                    Disciplinas disciplina = _disciplinaRepository.GetDisciplinaById(matricula.GetCodigoDisciplina());

                    if (disciplina == null)
                    {
                        continue;
                    }

                    qtd++;

                    double nota1 = matricula.GetNota1();
                    double nota2 = matricula.GetNota2();
                    double media = (nota1 + nota2) / 2.0;
                    double notaMinima = disciplina.GetNotaMinima();
                    string status = media >= notaMinima ? "Aprovado" : "Reprovado";

                    Console.WriteLine(
                        $"Disciplina: {disciplina.GetNomeDisciplina()} (Código: {disciplina.GetCodigoDisciplina()}) | " +
                        $"Nota 1: {nota1} | Nota 2: {nota2} | Média: {media} | Nota mínima: {notaMinima} | {status}");
                }

                if (qtd == 0)
                {
                    Console.WriteLine("Nenhuma disciplina vinculada ao aluno.");
                }
            }
        }

        public void AtribuirNotaAluno(string dadoAluno, string dadoDisciplina, double nota1, double nota2)
        {
            if (string.IsNullOrWhiteSpace(dadoAluno))
                throw new ArgumentException("Aluno inválido.");

            if (string.IsNullOrWhiteSpace(dadoDisciplina))
                throw new ArgumentException("Disciplina inválida.");

            if (nota1 < 0 || nota2 < 0)
                throw new ArgumentException("As notas devem ser maiores ou iguais a zero.");

            Alunos aluno = ResolverAlunos(dadoAluno);
            Disciplinas disciplina = ResolverDisciplinas(dadoDisciplina);

            Matriculas[] todasMatriculas = _matriculasRepository.GetAllMatriculas();

            for (int i = 0; i < todasMatriculas.Length; i++)
            {
                Matriculas matricula = todasMatriculas[i];

                if (matricula == null)
                    continue;

                if (matricula.GetMatriculaAluno() == aluno.GetMatriculaAluno() &&
                    matricula.GetCodigoDisciplina() == disciplina.GetCodigoDisciplina())
                {
                    matricula.SetNota1(nota1);
                    matricula.SetNota2(nota2);

                    if (!_matriculasRepository.Save(matricula))
                        throw new Exception("Falha ao salvar as notas da matrícula.");

                    Console.WriteLine("\nNotas atribuídas com sucesso.");
                    return;
                }
            }

            throw new Exception("Não existe matrícula para esse aluno nessa disciplina.");
        }

          
        private Alunos ResolverAlunos(string dadoAluno)
        {
            while (true)
            {
                if (int.TryParse(dadoAluno, out int mat))
                {
                    var aluno = _alunoRepository.GetAlunoByMatricula(mat);
                    
                    if (aluno != null)
                    {
                        return aluno;
                    }
                } else
                {
                    Alunos[] encontrados = _alunoRepository.GetAlunosByName(dadoAluno);

                    if (encontrados.Length == 1)
                    {
                        return encontrados[0];
                    }

                    if (encontrados.Length > 1)
                    {
                        Console.WriteLine("\nMais de um aluno foi encontrado: ");

                        for (int i = 0; i < encontrados.Length; i++)
                        {
                            Console.WriteLine($"{i + 1} - Matrícula: {encontrados[i].GetMatriculaAluno()} | Nome: {encontrados[i].GetNome()}" +
                                $" | Idade: {encontrados[i].GetIdade()}");
                        }

                        Console.Write("\nDigite a matrícula do aluno correto: ");
                        dadoAluno = Console.ReadLine();

                        continue;
                    }
                }

                Console.Write($"Dado do aluno ({dadoAluno}) não encontrado. Informe nome ou matrícula novamente: ");
                dadoAluno = Console.ReadLine();
            }
        }

        private Disciplinas ResolverDisciplinas(string dadoDisciplina)
        {
            while (true)
            {
                if (int.TryParse(dadoDisciplina, out int cod))
                {
                    var disciplina = _disciplinaRepository.GetDisciplinaById(cod);

                    if (disciplina != null)
                    {
                        return disciplina;
                    } 
                } else
                {
                    Disciplinas[] encontradas = _disciplinaRepository.GetDisciplinasByName(dadoDisciplina);

                    if (encontradas.Length == 1)
                    {
                        return encontradas[0];
                    }

                    if (encontradas.Length > 1)
                    {
                        Console.WriteLine("\nMais de uma disciplina foi encontrada: ");

                        for (int i = 0; i <  encontradas.Length; i++)
                        {
                            Console.WriteLine($"{i + 1} - Código: {encontradas[i].GetCodigoDisciplina()} | Nome: {encontradas[i].GetNomeDisciplina()}" +
                                $" | Nota Mínima: {encontradas[i].GetNotaMinima()}");
                        }

                        Console.Write("Digite o código da disciplina correta: ");
                        dadoDisciplina = Console.ReadLine();
                        continue;
                    }
                }

                Console.Write($"Dado da disciplina ({dadoDisciplina}) não encontrado. Informe nome ou código novamente: ");
                dadoDisciplina = Console.ReadLine();
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

        public bool Save(Matriculas[] matriculas)
        {
            if (matriculas == null || matriculas.Length == 0)
            {
                throw new ArgumentException("O número de matriculas é inválido.");
            }

            for (int i = 0; i < matriculas.Length; i++)
            {
                if (!_matriculasRepository.Save(matriculas[i]))
                {
                    throw new Exception($"Falha ao salvar a matrícula na posição {i}");
                }
            }

            return true;
        }
    }
}
