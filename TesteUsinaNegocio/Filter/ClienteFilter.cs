using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteUsinaNegocio.DTO;
using TesteUsinaPersistencia.Model;

namespace TesteUsinaNegocio.Filter
{
    public static class ClienteFilter
    {
        public static IQueryable<Cliente> ProdutoFiltro(this IQueryable<Cliente> query, ClienteFilterDTO dto)
        {
            if(dto != null)
            {
                if (dto.Codigo != null)
                {
                    query = query.Where(produto => produto.Codigo == dto.Codigo);
                }
                if (!string.IsNullOrEmpty(dto.Nome))
                {
                    query = query.Where(produto => produto.Nome == dto.Nome);
                }
                if (dto.Endereco != null)
                {
                    query = query.Where(produto => produto.Endereco == dto.Endereco);
                }
                if (dto.Cidade != null)
                {
                    query = query.Where(produto => produto.Cidade == dto.Cidade);
                }
                if (dto.Uf != null)
                {
                    query = query.Where(produto => produto.Uf == dto.Uf);
                }
                if (dto.DataInsercao != null)
                {
                    query = query.Where(produto => produto.DataInsercao == dto.DataInsercao);
                }
            }

            return query;
        }
    }
}
