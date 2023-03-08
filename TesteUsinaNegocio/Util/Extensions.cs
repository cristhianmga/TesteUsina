using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteUsinaNegocio.DTO.Ext;

namespace TesteUsinaNegocio.Util
{
    public static class Extensions
    {
        public static List<R> AsList<R>(this IEnumerable<dynamic> lista, IMapper mapper)
        {
            return mapper.Map<List<R>>(lista?.ToList());
        }

        public static PaginacaoDTO<R> AsPaginado<R>(this IQueryable<dynamic> query,PaginacaoConfigDTO config,IMapper mapper)
        {
            return new PaginacaoDTO<R>(query, mapper, config);
        }
    }
}
