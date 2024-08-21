using Auth.Controllers;
using Auth.Models;
using Auth.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Auth.Areas.Identity.Pages.ClientMedic
{
    public class MakeAppointmentPageModel : PageModel
    {
        private readonly ApplicationDBContext context;

        private readonly AppointmentsController appointmentsController;

        public List<ApplicationUser> Medics { get; set; } = new List<ApplicationUser>();

        public ApplicationUser Medic { get; set; } = new ApplicationUser();

        public string PatientId { get; private set; }

        public MakeAppointmentPageModel(ApplicationDBContext context, AppointmentsController appointmentsController)
        {
            this.context = context;
            this.appointmentsController = appointmentsController;
        }
        public void OnGet(string id)
        {
            Medic = context.Medics.Find(id);

            PatientId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
