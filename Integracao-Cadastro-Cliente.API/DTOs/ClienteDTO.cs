using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integracao_Cadastro_Cliente.API.DTOs
{
	public class ClienteDTO
	{
		public ClienteDTO()
		{
			this.Logradouros = new List<EnderecoDTO>();
		}
		public long Id { get; set; }
		public string Nome { get; set; }
		public string Email { get; set; }

		public List<EnderecoDTO> Logradouros { get; set; }

	}

}
