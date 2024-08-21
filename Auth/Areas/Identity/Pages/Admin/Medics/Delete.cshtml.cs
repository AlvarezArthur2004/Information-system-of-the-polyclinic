using Auth.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Auth.Areas.Identity.Pages.Admin.Medics
{
    public class DeleteModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ApplicationDBContext _context;

        public DeleteModel(IWebHostEnvironment environment, ApplicationDBContext context)
        {
            _environment = environment;
            _context = context;
        }

        public IActionResult OnGet(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound("Medic id not provided.");
            }

            var medic = _context.Medics.Find(id);

            if (medic == null)
            {
                return NotFound("Medic not found.");
            }

            string imageFullPath = $"{_environment.WebRootPath}/photos/{medic.ImageFileName}";

            if (System.IO.File.Exists(imageFullPath))
            {
                System.IO.File.Delete(imageFullPath);
            }

            _context.Medics.Remove(medic);
            _context.SaveChanges();

            return RedirectToPage("/Admin/Medics/Index");
        }
    }
}
