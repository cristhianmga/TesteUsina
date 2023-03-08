
namespace TesteUsinaPersistencia.Interface
{
    public interface IPadraoDB
    {
        Task<E> Salvar<E>(E entity) where E : class;
        Task<E> Atualizar<E>(E entity) where E : class;
        Task<string> Excluir<E>(int id) where E : class;
        Task<E> Obter<E>(int id) where E : class;
        IQueryable<E> ObterTodos<E>() where E : class;
    }
}
