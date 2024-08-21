using Auth.Models;
using Auth.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;


namespace Auth.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ApplicationDBContext context;
        private readonly DoctorDbContext contextSchedule;

        public List<ApplicationUser> Medics { get; set; } = new List<ApplicationUser>();
        public List<ApplicationUser> Medicsdoc { get; set; } = new List<ApplicationUser>();
        public List<AppointmentSlot> Schedule { get; set; } = new List<AppointmentSlot>();
        public List<AppointmentSlot> ScheduleForDoc { get; set; } = new List<AppointmentSlot>();
        public string PatientId { get; private set; }

        public string DoctorId { get; private set; }

        public PrivacyModel(ApplicationDBContext contextMed, DoctorDbContext contextSchedule)
        {
            this.context = contextMed;
            this.contextSchedule = contextSchedule;
        }

        public void OnGet()
        {
            IQueryable<ApplicationUser> query_med = context.Medics;

            IQueryable<AppointmentSlot> query_pac = contextSchedule.Appointments;

            PatientId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Schedule = query_pac.Where(slot => slot.PatientId == PatientId).ToList();

            var scheduleIds = Schedule.Select(slot => slot.DoctorId).ToList();

            Medics = query_med.Where(medic => scheduleIds.Contains(medic.Id)).ToList();



            ScheduleForDoc = query_pac.Where(slot => slot.DoctorId == PatientId).ToList();

            var scheduleIdsfordoc = ScheduleForDoc.Select(slot => slot.PatientId).ToList();

            Medicsdoc = query_med.Where(medic => scheduleIdsfordoc.Contains(medic.Id)).ToList();


        }
    }

}