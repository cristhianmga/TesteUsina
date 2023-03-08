using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteUsinaNegocio.DTO;
using TesteUsinaNegocio.DTO.Ext;

namespace TesteUsinaNegocio.Interface
{
    public interface IClienteService
    {
        Task<ClienteDTO> SalvarAsync(ClienteDTO cliente);
        Task<ClienteDTO> AtualizarAsync(ClienteDTO cliente);
        Task<string> ExcluirAsync(int codigo);
        Task<ClienteDTO> ObterAsync(int codigo);
        Task<PaginacaoDTO<ClienteDTO>> ObterTodosPaginadoAsync(ClienteFilterDTO filtro, PaginacaoConfigDTO config);
        Task<List<ClienteDTO>> ObterTodosAsync();
    }
}
