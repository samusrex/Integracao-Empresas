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
    public class DeleteModel : PageModel
    {
        private readonly Integracao_Cadastro_Cliente.API.Models.EmpresaPadraoContext _context;

        public DeleteModel(Integracao_Cadastro_Cliente.API.Models.EmpresaPadraoContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cliente = await _context.Clientes.FindAsync(id);

            if (Cliente != null)
            {
                _context.Clientes.Remove(Cliente);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
