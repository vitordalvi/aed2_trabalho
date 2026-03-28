using aed2_trabalho.Entities;
using aed2_trabalho.Repositories;

namespace aed2_trabalho.Services
{
    public class AlunosService
    {
        private readonly IAlunoRepository _alunoRepository;
        public AlunosService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public Alunos[] CreateAlunos(string[] nomes, int[] idades)
        {
            if (nomes == null || idades == null)
                throw new ArgumentException("Vetores não podem ser nulos.");

            if (nomes.Length == 0 || idades.Length == 0)
                throw new ArgumentException("Vetores não podem estar vazios.");

            if (nomes.Length != idades.Length)
                throw new ArgumentException("A quantidade de nomes e idades deve ser igual.");

            Alunos[] alunosCriados = new Alunos[nomes.Length];

            for (int i = 0; i < nomes.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(nomes[i]))
                    throw new ArgumentException($"Nome inválido na posição {i}.");

                if (idades[i] <= 0)
                    throw new ArgumentException($"Idade inválida na posição {i}.");

                var aluno = _alunoRepository.AddAluno(nomes[i], idades[i]);

                if (aluno == null)
                    throw new Exception($"Falha ao criar aluno na posição {i}.");

                if (!_alunoRepository.Save(aluno))
                    throw new Exception($"Falha ao salvar aluno na posição {i}.");

                alunosCriados[i] = aluno;
            }

            return alunosCriados;
        }

        public bool Save(Alunos[] alunos)
        {
            if (alunos == null || alunos.Length == 0)
            {
                throw new ArgumentException("O número de alunos é inválido.");
            }

            for (int i = 0; i < alunos.Length; i++)
            {
                if (!_alunoRepository.Save(alunos[i]))
                {
                    throw new Exception($"Falha ao salvar o aluno na posição {i}");
                }
            }

            return true;
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

    }
}
