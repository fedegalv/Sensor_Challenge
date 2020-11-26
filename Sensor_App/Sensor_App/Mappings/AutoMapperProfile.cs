using AutoMapper;
using Sensor_App.Models;
using Sensor_App.Models.ViewModel;

namespace GestionReclamosRemastered.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Usuario

            CreateMap<UserViewModel, User>().ReverseMap();      
            


           
        }
    }
}