using Integracao_Cadastro_Cliente.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integracao_Cadastro_Cliente.API.Repositories
{
	public interface IClienteRepository : IBaseRepository<Cliente>
	{
		IEnumerable<Cliente> GetClientWithAddress();
		bool CheckIfEmailAlreadyExists(string email);

		void Save();
		
	}
}
