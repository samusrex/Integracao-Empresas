using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Integracao_Cadastro_Cliente.API.Models;

namespace Integracao_Cadastro_Clientes.Application.Pages.Clientes
{
    public class CreateModel : PageModel
    {
        private readonly Integracao_Cadastro_Cliente.API.Models.EmpresaPadraoContext _context;

        public CreateModel(Integracao_Cadastro_Cliente.API.Models.EmpresaPadraoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Cliente Cliente { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Clientes.Add(Cliente);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
