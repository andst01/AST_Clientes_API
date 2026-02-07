using AutoMapper;
using Clientes.Application.DTO;
using Clientes.Application.Request;
using Clientes.Domain.Entidades;


namespace Clientes.Infra.CrossCuting.AutoMapper
{
    public class DTOToDomainMappingProfile : Profile
    {
        public DTOToDomainMappingProfile()
        {
            CreateMap<ClienteDTO, Cliente>();
            CreateMap<ClienteRequest, Cliente>();
        }
    }
}
