using Auth.Controllers;
using Auth.Models;
using Auth.Services;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Auth.Areas.Identity.Pages.ClientMedic
{
    public class DoctorInfoModel : PageModel
    {
		private readonly IWebHostEnvironment _hostingEnvironment;

        private readonly ApplicationDBContext _context;

        public List<ApplicationUser> Medics { get; set; } = new List<ApplicationUser>();

        public ApplicationUser Medic { get; set; } = new ApplicationUser();

        private readonly CommentDbContext _contextcomment;

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public string PatientId { get; private set; }
        public DoctorInfoModel(IWebHostEnvironment hostingEnvironment, ApplicationDBContext context, CommentDbContext contextcomment)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
            _contextcomment = contextcomment;
        }
        public void OnGet(string id)
        {
            Medic = _context.Medics.Find(id);

            Medics = _context.Medics.ToList();

            PatientId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Comments = _contextcomment.Comments.Where(c => c.MedicId == id).ToList();

        }


        public IActionResult AddComment(string id, string iddoctor, string text, string rating)
        {
            var comment = new Comment
            {
                Text = text,
                MedicId = iddoctor,
                PacientId = id,
                Rate = rating,
                CreatedAt = DateTime.Now
            };

            _contextcomment.Comments.Add(comment);
            _contextcomment.SaveChanges();

            return Redirect($"/Identity/ClientMedic/MakeAppointmentPage?id={iddoctor}");
        }
    }
}
