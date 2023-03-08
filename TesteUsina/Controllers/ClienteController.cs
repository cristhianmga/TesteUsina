using Microsoft.AspNetCore.Mvc;
using TesteUsinaNegocio.DTO;
using TesteUsinaNegocio.DTO.Ext;
using TesteUsinaNegocio.Interface;

namespace TesteUsina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService) 
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Salvar(ClienteDTO cliente)
        {
            try
            {
                return Ok(await _clienteService.SalvarAsync(cliente));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Atualizar(ClienteDTO cliente)
        {
            try
            {
                return Ok(await _clienteService.AtualizarAsync(cliente));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> Excluir(int codigo)
        {
            try
            {
                return Ok(await _clienteService.ExcluirAsync(codigo));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("{codigo}")]
        public async Task<IActionResult> Obter(int codigo)
        {
            try
            {
                return Ok(await _clienteService.ObterAsync(codigo));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("paginado")]
        public async Task<IActionResult> ObterTodos([FromQuery]PaginacaoClientesDTO paginacaoClientes)
        {
            try
            {
                return Ok(await _clienteService.ObterTodosPaginadoAsync(paginacaoClientes.FilterDTO, paginacaoClientes.PaginacaoDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> ObterTodosSemPaginacao()
        {
            try
            {
                return Ok(await _clienteService.ObterTodosAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
