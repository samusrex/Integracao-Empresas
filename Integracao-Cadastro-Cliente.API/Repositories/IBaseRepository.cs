using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Integracao_Cadastro_Cliente.API.Repositories
{
	public interface IBaseRepository<T> where T: class
	{
		IEnumerable<T> FindAll();
		T Get(long id);
		void Create(T entity);
		void Update(T entity);
		void Delete(T entity);
	}
}
