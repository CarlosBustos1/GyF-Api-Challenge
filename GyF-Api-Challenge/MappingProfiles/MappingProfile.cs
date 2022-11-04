using AutoMapper;
using GyF_Api_Challenge.Models;

namespace GyF_Api_Challenge.MappingProfiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateClienteModel, ClienteModel>();
            CreateMap<UpdateClienteModel, ClienteModel>();
        }
    }
}
