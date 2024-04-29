using System;
using System.Collections.Generic;

#nullable disable

namespace Integracao_Cadastro_Cliente.API.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            ClienteLogradouros = new HashSet<ClienteLogradouro>();
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public byte[] Logotipo { get; set; }

        public virtual ICollection<ClienteLogradouro> ClienteLogradouros { get; set; }
    }
}
