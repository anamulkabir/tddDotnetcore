using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspnetCoreTDD.Data;
using AspnetCoreTDD.Models;

namespace AspnetCoreTDD.Pages_UserCred
{
    public class DetailsModel : PageModel
    {
        private readonly AspnetCoreTDD.Data.UserCredContext _context;

        public DetailsModel(AspnetCoreTDD.Data.UserCredContext context)
        {
            _context = context;
        }

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
    }
}
