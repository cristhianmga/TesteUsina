
using TesteUsinaNegocio.DTO.Ext;

namespace TesteUsinaNegocio.DTO
{
    public class PaginacaoClientesDTO
    {
        public ClienteFilterDTO? FilterDTO { get; set; }
        public PaginacaoConfigDTO PaginacaoDTO { get; set; }
    }
}
