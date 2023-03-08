using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using TesteUsinaNegocio.DTO;
using TesteUsinaNegocio.DTO.Ext;
using TesteUsinaNegocio.Filter;
using TesteUsinaNegocio.Interface;
using TesteUsinaNegocio.Util;
using TesteUsinaPersistencia.Interface;
using TesteUsinaPersistencia.Model;

namespace TesteUsinaNegocio.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        private IValidator<ClienteDTO> _validator;
        public ClienteService(IClienteRepository clienteRepository, IMapper mapper, IValidator<ClienteDTO> validator) 
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<ClienteDTO> SalvarAsync(ClienteDTO produto)
        {
            ValidationResult validation = await _validator.ValidateAsync(produto);
            if(validation.IsValid)
            {
                produto.DataInsercao = DateTime.Now;
                Cliente retorno = await _clienteRepository.Salvar(_mapper.Map<Cliente>(produto));
                return _mapper.Map<ClienteDTO>(retorno);
            }
            else
            {
                throw new Exception(validation.ToString());
            }
        }

        public async Task<ClienteDTO> AtualizarAsync(ClienteDTO produto)
        {
            ValidationResult validation = await _validator.ValidateAsync(produto);
            if (validation.IsValid)
            {
                Cliente retorno = await _clienteRepository.Atualizar(_mapper.Map<Cliente>(produto));
            return _mapper.Map<ClienteDTO>(retorno);
            }
            else
            {
                throw new Exception(validation.ToString());
            }
        }

        public async Task<string> ExcluirAsync(int codigo)
        {
            string retorno = await _clienteRepository.Excluir(codigo);
            return retorno;
        }

        public async Task<ClienteDTO> ObterAsync(int codigo)
        {
            Cliente produto = await _clienteRepository.GetProdutoByCodigo(codigo);
            return _mapper.Map<ClienteDTO>(produto);
        }
        
        public async Task<PaginacaoDTO<ClienteDTO>> ObterTodosPaginadoAsync(ClienteFilterDTO filtro, PaginacaoConfigDTO config)
        {
            IQueryable<Cliente> lista = await _clienteRepository.ObterTodos();
            PaginacaoDTO<ClienteDTO> listaPaginada = lista.ProdutoFiltro(filtro).AsPaginado<ClienteDTO>(config, _mapper);
            return listaPaginada;
        }

        public async Task<List<ClienteDTO>> ObterTodosAsync()
        {
            IQueryable<Cliente> lista = await _clienteRepository.ObterTodos();
            return lista.AsList<ClienteDTO>(_mapper);
        }

    }
}
