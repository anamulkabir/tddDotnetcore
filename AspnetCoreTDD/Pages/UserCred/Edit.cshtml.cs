using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspnetCoreTDD.Data;
using AspnetCoreTDD.Models;

namespace AspnetCoreTDD.Pages_UserCred
{
    public class EditModel : PageModel
    {
        private readonly AspnetCoreTDD.Data.UserCredContext _context;

        public EditModel(AspnetCoreTDD.Data.UserCredContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserCred UserCred { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserCred = await _context.UserCreds.FirstOrDefaultAsync(m => m.UserCredID == id);

            if (UserCred == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(UserCred).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserCredExists(UserCred.UserCredID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UserCredExists(int id)
        {
            return _context.UserCreds.Any(e => e.UserCredID == id);
        }
    }
}
