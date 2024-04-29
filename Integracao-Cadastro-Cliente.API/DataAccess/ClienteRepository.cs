using Integracao_Cadastro_Cliente.API.Models;
using Integracao_Cadastro_Cliente.API.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integracao_Cadastro_Cliente.API.DataAccess
{
	
	public class ClienteRepository : IClienteRepository
	{

		private readonly EmpresaPadraoContext _context;

		public ClienteRepository(EmpresaPadraoContext context)
		{
			_context = context;
		}

		public bool CheckIfEmailAlreadyExists(string email)
		{
			return _context.Clientes.Where(c => c.Email.Trim() == email.Trim()).Any() ;
		}

		public void Create(Cliente entity)
		{
			_context.Clientes.Add(entity);
			

		}
		public void Save() {

			_context.SaveChanges();
		}

		public void Delete(Cliente entity)
		{
			_context.Clientes.Remove(entity);
			
		}

		public IEnumerable<Cliente> FindAll()
		{
			IEnumerable<Cliente> qry = _context
				.Clientes
								.AsQueryable()
				.Cast<Cliente>()
				.Select(x=>x)
				;

			return qry;
		}

		public Cliente Get(long clienteId)
		{
			 return _context.Clientes
				.Include(c=>c.ClienteLogradouros)
				.FirstOrDefault(x => x.Id == clienteId);
		}

		public IEnumerable<Cliente> GetClientWithAddress()
		{
			IEnumerable<Cliente> qry = _context
					.Clientes
					.Include(c=>c.ClienteLogradouros)
					.AsQueryable()
					.Cast<Cliente>()
					.Select(x => x)
					;

			return qry;
		}

		public void Update(Cliente entity)
		{
			_context.Clientes.Update(entity);
			
		}
	}
}
