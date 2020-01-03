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
    public class IndexModel : PageModel
    {
        private readonly AspnetCoreTDD.Data.UserCredContext _context;

        public IndexModel(AspnetCoreTDD.Data.UserCredContext context)
        {
            _context = context;
        }

        public IList<UserCred> UserCred { get;set; }

        public async Task OnGetAsync()
        {
            UserCred = await _context.UserCreds.ToListAsync();
        }
    }
}
