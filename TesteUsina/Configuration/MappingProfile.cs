using AutoMapper;
using TesteUsinaNegocio.DTO;
using TesteUsinaPersistencia.Model;

namespace TesteUsina.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
        }
    }
}
