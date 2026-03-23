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
    }
}
