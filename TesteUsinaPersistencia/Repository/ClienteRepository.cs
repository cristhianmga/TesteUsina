
using Microsoft.EntityFrameworkCore;
using TesteUsinaPersistencia.Interface;
using TesteUsinaPersistencia.Model;

namespace TesteUsinaPersistencia.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IPadraoDB _padraoDB;
        public ClienteRepository(IPadraoDB padraoDB) 
        {
            _padraoDB = padraoDB;
        }

        public async Task<Cliente> GetProdutoByCodigo(int codigo) 
        {
            Cliente cliente = await _padraoDB.Obter<Cliente>(codigo);
            if (cliente == null)
            {
                throw new NullReferenceException("Produto não encontrado");
            }
            else
            {
                return cliente;
            }
        }

        public async Task<Cliente> Salvar(Cliente cliente)
        {
            Cliente retorno = await _padraoDB.Salvar(cliente);
            return retorno;
        }

        public async Task<string> Excluir(int codigo)
        {
            return await _padraoDB.Excluir<Cliente>(codigo);
        }

        public async Task<Cliente> Atualizar(Cliente cliente)
        {
            Cliente retorno = await _padraoDB.Atualizar(cliente);
            return retorno;
        }

        public async Task<IQueryable<Cliente>> ObterTodos()
        {
            IQueryable<Cliente> clientes =  _padraoDB.ObterTodos<Cliente>();
            return clientes;
        }
    }
}
