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
            for (int i = 0; i < alunos.Length; i++)
            {
                var save = _alunoRepository.Save(alunos[i]);

                if (save == false)
                {
                    throw new Exception("Falha ao salvar alunos.");
                }

                Console.WriteLine($"Alunos criados com sucesso.\nID: {alunos[i].GetMatriculaAluno()}, Nome: {alunos[i].GetNome()}, Idade: {alunos[i].GetIdade()}\n");
            }

            return true;
        }

    }
}
