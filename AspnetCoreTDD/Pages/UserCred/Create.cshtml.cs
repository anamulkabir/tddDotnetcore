using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspnetCoreTDD.Data;
using AspnetCoreTDD.Models;

namespace AspnetCoreTDD.Pages_UserCred
{
    public class CreateModel : PageModel
    {
        private readonly AspnetCoreTDD.Data.UserCredContext _context;

        public CreateModel(AspnetCoreTDD.Data.UserCredContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UserCred UserCred { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UserCreds.Add(UserCred);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
