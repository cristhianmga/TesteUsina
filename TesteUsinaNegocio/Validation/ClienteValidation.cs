using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteUsinaNegocio.DTO;

namespace TesteUsinaNegocio.Validation
{
    public class ClienteValidation : AbstractValidator<ClienteDTO>
    {
        public ClienteValidation() 
        {
        }

    }
}
