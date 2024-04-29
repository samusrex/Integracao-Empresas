using Integracao_Cadastro_Cliente.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integracao_Cadastro_Cliente.API.Repositories
{
	public interface ILogradouroRepository:IBaseRepository<Logradouro>
	{
		IEnumerable<Logradouro> GetAllAddressAttached(long clienteId);
		Logradouro FindOne(long clienteId);

		void Save();
	}
}
