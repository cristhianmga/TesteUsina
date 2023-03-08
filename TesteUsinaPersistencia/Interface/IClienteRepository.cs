using TesteUsinaPersistencia.Model;

namespace TesteUsinaPersistencia.Interface
{
    public interface IClienteRepository
    {
        Task<Cliente> GetProdutoByCodigo(int codigo);
        Task<Cliente> Salvar(Cliente cliente);
        Task<string> Excluir(int codigo);
        Task<Cliente> Atualizar(Cliente produto);
        Task<IQueryable<Cliente>> ObterTodos();
    }
}
