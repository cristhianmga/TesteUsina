using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteUsinaNegocio.DTO
{
    public class ClienteFilterDTO
    {
        public int? Codigo { get; set; }
        public string? Nome { get; set; }
        public string? Endereco { get; set; }
        public string? Cidade { get; set; }
        public string? Uf { get; set; }
        public DateTime? DataInsercao { get; set; }
    }
}
