using AutoMapper;
using DAO.DTO;
using MVC.Models.Entreprise;

namespace MVC.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<EntreprisePartialDTO, EntreprisePartialViewModel>().ReverseMap();
        }
    }
}
