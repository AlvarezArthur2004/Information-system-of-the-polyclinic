using Auth.Models;
using Auth.Services;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Auth.Areas.Identity.Pages.Account
{
    public class InfoPageProfileModel : PageModel
    {
        private readonly ApplicationDBContext _context;

        public ApplicationUser Pacient { get; set; }

        public InfoPageProfileModel(ApplicationDBContext context)
        {
            _context = context;
        }

        public void OnGet(string id)
        {
            var medic = _context.Medics.Find(id);

            Pacient = _context.Medics.FirstOrDefault(d => d.Id == id);
        }
    }
}
