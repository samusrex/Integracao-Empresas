using System;
using System.Collections.Generic;

#nullable disable

namespace Integracao_Cadastro_Cliente.API.Models
{
    public partial class Logradouro
    {
        public long LogradouroId { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
