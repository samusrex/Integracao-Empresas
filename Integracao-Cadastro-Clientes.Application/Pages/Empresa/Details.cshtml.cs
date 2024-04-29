using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Integracao_Cadastro_Cliente.API.Models;

namespace Integracao_Cadastro_Clientes.Application.Pages.Clientes
{
    public class DetailsModel : PageModel
    {
        private readonly Integracao_Cadastro_Cliente.API.Models.EmpresaPadraoContext _context;

        public DetailsModel(Integracao_Cadastro_Cliente.API.Models.EmpresaPadraoContext context)
        {
            _context = context;
        }

        public Cliente Cliente { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cliente = await _context.Clientes.FirstOrDefaultAsync(m => m.Id == id);

            if (Cliente == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
