using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Integracao_Cadastro_Cliente.API.Models;
using Integracao_Cadastro_Cliente.API.DTOs;
using Integracao_Cadastro_Cliente.API.Repositories;

namespace Integracao_Cadastro_Clientes.Application.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        private readonly Integracao_Cadastro_Cliente.API.Models.EmpresaPadraoContext _context;
       

        public IndexModel(EmpresaPadraoContext context)
        {
            _context = context;
        }

        public IList<Cliente> Cliente { get;set; }

        public async Task OnGetAsync()
        {
            Cliente = await _context.Clientes.ToListAsync();
        }
    }
}
