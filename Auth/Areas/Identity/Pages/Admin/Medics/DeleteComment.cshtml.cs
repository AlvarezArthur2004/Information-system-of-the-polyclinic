using Auth.Models;
using Auth.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Auth.Areas.Identity.Pages.Admin.Medics
{
    public class DeleteCommentModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;
        private readonly CommentDbContext _context;

        public DeleteCommentModel(IWebHostEnvironment environment, CommentDbContext context)
        {
            _environment = environment;
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            var medic = _context.Comments.Find(id);

            if (medic == null)
            {
                return NotFound("Comment not found.");
            }

            _context.Comments.Remove(medic);
            _context.SaveChanges();

            return RedirectToPage("/Admin/Medics/Index");
        }
    }
}
