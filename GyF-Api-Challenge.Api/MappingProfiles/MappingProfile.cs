using AutoMapper;
using GyF_Api_Challenge.Api.Models;
using GyF_Api_Challenge.Core.Dtos;
using GyF_Api_Challenge.Core.Enums;
using GyF_Api_Challenge.Core.Models;

namespace GyF_Api_Challenge.Api.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BaseClienteModel, BaseClienteDto>();
            CreateMap<UpdateClienteModel, UpdateClienteDto>();

            CreateMap<BaseClienteDto, Cliente>();
            CreateMap<UpdateClienteDto, Cliente>();

            CreateMap<Cliente, ClienteDto>();
            CreateMap<ClienteDto, ClienteModel>();

        }

        //public class GeneroResolver : IValueResolver<KeyValuePair<int>, GeneroEnum>
        //{
        //    public int Resolve(Source source, Destination destination, int member, ResolutionContext context)
        //    {
        //        return source.Value1 + source.Value2;
        //    }
        //}

        //public class ToEnumGeneroResolver : IValueResolver<Cliente, BaseClienteDto, KeyValueDto<int>>
        //{
        //    public KeyValueDto<int> Resolve(Cliente source, BaseClienteDto destination, KeyValueDto<int> destMember, ResolutionContext context)
        //    {
        //        switch (source.Genero)
        //        {
        //            case GeneroEnum.Masculino:
        //                return new KeyValueDto<int>(1, "Masculino");

        //            case GeneroEnum.Femenino:
        //                return new KeyValueDto<int>(2, "Femenino");

        //            case GeneroEnum.NoBinario:
        //                return new KeyValueDto<int>(3, "No Bibario");

        //            default:
        //                throw new Exception("Valor invalido de genero");
        //        }
        //    }
        //}

        //public class IntToKeyValueGeneroResolver : IValueResolver<CreateClienteModel, BaseClienteDto, GeneroEnum>
        //{
        //    public GeneroEnum Resolve(CreateClienteModel source, BaseClienteDto destination, GeneroEnum destMember, ResolutionContext context)
        //    {
        //        switch (source.Genero)
        //        {
        //            case 1:
        //                return GeneroEnum.Masculino;
        //            case 2:
        //                return GeneroEnum.Femenino;
        //            case 3:
        //                return GeneroEnum.NoBinario;
        //            default:
        //                throw new Exception("Valor invalido de genero");
        //        }

        //    }
        //}
    }
}

