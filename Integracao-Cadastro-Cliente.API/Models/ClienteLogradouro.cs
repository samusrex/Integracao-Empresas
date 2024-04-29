using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace Integracao_Cadastro_Cliente.API.Models
{
    public partial class ClienteLogradouro
    {
        public int Id { get; set; }
        public long ClienteId { get; set; }
        public long LogradouroId { get; set; }

        [JsonIgnore]
        public virtual Cliente Cliente { get; set; }
    }
}
