using AutoMapper;
using Clientes.Application.DTO;
using Clientes.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Infra.CrossCuting.AutoMapper
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>();
        }
    }
}
