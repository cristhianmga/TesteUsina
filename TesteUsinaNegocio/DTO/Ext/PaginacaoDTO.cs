using AutoMapper;
using TesteUsinaNegocio.Util;

namespace TesteUsinaNegocio.DTO.Ext
{
    public class PaginacaoDTO<R>
    {
        private IQueryable<dynamic> listaObjeto;
        private readonly IMapper _mapper;
        private PaginacaoConfigDTO config;

        public PaginacaoDTO(IQueryable<dynamic> listaObjeto, IMapper mapper, PaginacaoConfigDTO config)
        {
            this.listaObjeto = listaObjeto;
            this._mapper = mapper;
            this.config = config;
        }
        public List<R> content
        {
            get
            {
                return listaObjeto.Count() != 0 ? listaObjeto.Skip(number * numbersOfElements).Take(numbersOfElements).AsList<R>(_mapper) : null;
            }
        }

        public int? totalElements
        {
            get
            {
                return listaObjeto.Count() != 0 ? listaObjeto.Count() : 0;
            }
        }

        public int totalPages
        {
            get
            {
                return listaObjeto.Count() != 0 ? (int)Math.Ceiling(listaObjeto.Count() / (decimal)(config?.size ?? 1)) : 0;
            }
        }

        public int numbersOfElements
        {
            get
            {
                return listaObjeto.Count() != 0 ? config?.size ?? 10 : 0;
            }
        }

        public int number
        {
            get
            {
                return config?.page ?? 0;
            }
        }
    }
}
