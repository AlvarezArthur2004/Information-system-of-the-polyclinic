using Auth.Models;
using Auth.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Auth.Areas.Identity.Pages.ClientMedic
{
    public class DeleteAppointmentModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ApplicationDBContext _context;
        private readonly DoctorDbContext _appointmentsController;

        public DeleteAppointmentModel(IWebHostEnvironment environment, ApplicationDBContext context, DoctorDbContext appointmentsController)
        {
            _environment = environment;
            _context = context;
            _appointmentsController = appointmentsController;
        }

        public IActionResult OnGet(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound("Appoinjtment id not provided.");
            }

            var appointmentid = _appointmentsController.Appointments.Find(Convert.ToInt32(id));


            if (appointmentid == null)
            {
                return NotFound("Appoinjtment not found.");
            }

            _appointmentsController.Appointments.Remove(appointmentid);
            _appointmentsController.SaveChanges();

            return RedirectToPage("/Privacy");
        }
    }
}
