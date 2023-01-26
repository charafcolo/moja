using AutoMapper;
using DAO.DAO;
using DAO.Models;
using MVC.Models.Entreprise;

namespace MVC.Services
{
    public class EntrepriseService : IEntrepriseService
    {
        private readonly IEntrepriseDAO _dao;
        private readonly IMapper _mapper;

        public EntrepriseService(IEntrepriseDAO dao, IMapper mapper)
        {
            _dao = dao;

            _mapper = mapper;
        }

        public async Task Create(Entreprise entreprise)
        {
            await _dao.Create(entreprise);
        }

        public async Task Delete(int id)
        {
            await _dao.Delete(id);
        }

        public async Task<List<EntreprisePartialViewModel>> GetAll()
        {
            // List<EntreprisePartialViewModel> entreprisesVM = new();

            // (await _dao.GetAll()).ForEach(e => entreprisesVM.Add(new (e.Id, e.Nom)));

            // return entreprisesVM;

            // On transforme une liste de Type EntreprisePartialDTO en EntreprisePartialViewModel grace à un mapper 
            // Le mapper a été injecté dans le constructeur du service
            // Pour pouvoir utilise le mammper il faut :
            // - ajouter le package : AutoMapper.Extensions.Microsoft.DependencyInjection
            // - Créer un dossier Helpers et une classe 'AutoMapperProfile'
            // Ajouter dans program.cs : builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

            return _mapper.Map<List<EntreprisePartialViewModel>>((await _dao.GetAll()));
        }

        public Task<Entreprise?> GetById(int id)
        {
            return _dao.GetById(id);
        }

        public async Task Update(Entreprise p)
        {
            await _dao.Update(p);
        }
    }
}
