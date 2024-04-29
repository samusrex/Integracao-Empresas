using Integracao_Cadastro_Cliente.API.Models;
using Integracao_Cadastro_Cliente.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integracao_Cadastro_Cliente.API.DataAccess
{
	public class LogradouroRepository : ILogradouroRepository
	{
		private readonly EmpresaPadraoContext _context;

		public LogradouroRepository(EmpresaPadraoContext context)
		{
			_context = context;
		}

		public void Create(Logradouro entity)
		{
			_context.Logradouros.Add(entity);
			
		}

		public void Delete(Logradouro entity)
		{
			_context.Logradouros.Remove(entity);
		
		}

		public IEnumerable<Logradouro> FindAll()
		{
			return _context.Logradouros.ToList();
		}

		public Logradouro FindOne(long clienteId)
		{
			var pesquisa_relacionamento = _context.ClienteLogradouros.FirstOrDefault(x => x.ClienteId == clienteId);
			return _context.Logradouros.FirstOrDefault(x=>x.LogradouroId == pesquisa_relacionamento.LogradouroId);
		}

		public Logradouro Get(long id)
		{
			return _context.Logradouros.Find(id);
		}

		public IEnumerable<Logradouro> GetAllAddressAttached(long clienteId)
		{
			var clientes_endereco = _context.ClienteLogradouros.Where(x => x.ClienteId == clienteId);
			
			var endereco_completo = new List<Logradouro>();
			foreach(var item in clientes_endereco)
			{
				var endereco = _context.Logradouros.Find(item.ClienteId);
				endereco_completo.Add(endereco);

			}
			return endereco_completo;			
		}

		public void Update(Logradouro entity)
		{
			_context.Logradouros.Update(entity);
			
		}

		public void Save()
		{
			_context.SaveChanges();

		}
	}
}
