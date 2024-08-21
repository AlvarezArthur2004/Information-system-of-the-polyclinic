using Auth.Models;
using Auth.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace Auth.Areas.Identity.Pages.ClientMedic
{
    public class AppointmentInfoModel : PageModel
    {
        private readonly ApplicationDBContext _context;
        private readonly DoctorDbContext _contextSchedule;

        public AppointmentSlot Schedule { get; set; } 
        public ApplicationUser Doctor { get; set; }
        public string SlotIdOut { get; set; }


        public AppointmentInfoModel(ApplicationDBContext context, DoctorDbContext contextSchedule)
        {
            _context = context;
            _contextSchedule = contextSchedule;
        }

        public IActionResult OnGet(string id, string slotIdout)
        {
            if (id == null || slotIdout == null)
            {
                return NotFound();
            }

            Doctor = _context.Medics.FirstOrDefault(d => d.Id == id);

            if (Doctor == null)
            {
                return NotFound();
            }

            SlotIdOut = slotIdout;

            // Находим объект AppointmentSlot по переданному id
            Schedule = _contextSchedule.Appointments.FirstOrDefault(s => s.Id == Convert.ToInt32(slotIdout));

            if (Schedule != null)
            {
                // Вы можете использовать данные Schedule здесь
            }

            return Page();
        }
    }
}
