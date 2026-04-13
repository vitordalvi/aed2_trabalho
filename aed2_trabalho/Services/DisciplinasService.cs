using aed2_trabalho.entities;
using aed2_trabalho.Entities;
using aed2_trabalho.Repositories;

namespace aed2_trabalho.Services
{
    public class DisciplinasService
    {
        private readonly IDisciplinasRepository _disciplinasRepository;
        public DisciplinasService(IDisciplinasRepository disciplinasRepository)
        {
            _disciplinasRepository = disciplinasRepository;
        }

        public Disciplinas[] CreateDisciplinas(string[] nomes, double[] notasMinimas)
        {
            if (nomes == null || notasMinimas == null)
                throw new ArgumentException("Vetores não podem ser nulos.");

            if (nomes.Length == 0 || notasMinimas.Length == 0)
                throw new ArgumentException("Vetores não podem estar vazios.");

            if (nomes.Length != notasMinimas.Length)
                throw new ArgumentException("A quantidade de nomes e idades deve ser igual.");

            Disciplinas[] disciplinasCriadas = new Disciplinas[nomes.Length];

            for (int i = 0; i < nomes.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(nomes[i]))
                    throw new ArgumentException($"Nome inválido na posição {i}.");

                if (notasMinimas[i] <= 0)
                    throw new ArgumentException($"Nota mínima inválida na posição {i}.");

                var disciplina = _disciplinasRepository.AddDisciplina(nomes[i], notasMinimas[i]);

                if (disciplina == null)
                    throw new Exception($"Falha ao criar aluno na posição {i}.");

                if (!_disciplinasRepository.Save(disciplina))
                    throw new Exception($"Falha ao salvar aluno na posição {i}.");

                disciplinasCriadas[i] = disciplina;
            }

            return disciplinasCriadas;
        }

        public Disciplinas[] ConsultarTodasDisciplinas()
        {
            return _disciplinasRepository.GetAllDisciplinas();
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

        public bool Save(Disciplinas[] disciplinas)
        {
            if (disciplinas == null || disciplinas.Length == 0)
            {
                throw new ArgumentException("O número de disciplinas é inválido.");
            }

            for (int i = 0; i < disciplinas.Length; i++)
            {
                if (!_disciplinasRepository.Save(disciplinas[i]))
                {
                    throw new Exception($"Falha ao salvar o aluno na posição {i}");
                }
            }

            return true;
        }
    }
}
