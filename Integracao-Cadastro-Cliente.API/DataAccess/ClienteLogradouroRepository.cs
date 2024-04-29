using Integracao_Cadastro_Cliente.API.Models;
using Integracao_Cadastro_Cliente.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integracao_Cadastro_Cliente.API.DataAccess
{
	public class ClienteLogradouroRepository : IClientLogradouroRepository
	{
		private readonly EmpresaPadraoContext _context;

		public ClienteLogradouroRepository(EmpresaPadraoContext context)
		{
			_context = context;
		}
		

		public void CreateRelations(Cliente cli, long clienteId, long enderecoId)
		{
			var relations = new ClienteLogradouro();
			relations.Cliente = cli;
			relations.ClienteId = clienteId;
			relations.LogradouroId = enderecoId;

			_context.ClienteLogradouros.Add(relations);
			_context.SaveChanges();

		}
	}
}
