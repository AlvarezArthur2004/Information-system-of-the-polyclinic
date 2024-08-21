using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.Models;
using Auth.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {

        public List<ApplicationUser> Medics { get; set; } = new List<ApplicationUser>();


        [HttpGet("patient/{id}")]
        public async Task<ActionResult<ApplicationUser>> GetMedic(string id)
        {
            var medic = await _contextUsers.Medics.FindAsync(id);

            if (medic == null)
            {
                return NotFound("Medic not found");
            }

            return Ok(medic); 
        }

        private readonly DoctorDbContext _context;

        private readonly ApplicationDBContext _contextUsers;


        public AppointmentsController(DoctorDbContext context, ApplicationDBContext contextUsers)
        {
            _context = context;
            _contextUsers = contextUsers;
        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentSlot>>> GetAppointments([FromQuery] DateTime start, [FromQuery] DateTime end, [FromQuery] string doctorId)
        {
            IQueryable<AppointmentSlot> query = _context.Appointments.Where(e => !((e.End <= start) || (e.Start >= end)));

            if (!string.IsNullOrEmpty(doctorId))
            {
                query = query.Where(e => e.DoctorId == doctorId);
            }

            return await query.ToListAsync();
        }


        [HttpGet("free")]
        public async Task<ActionResult<IEnumerable<AppointmentSlot>>> GetFreeAppointments([FromQuery] DateTime start, [FromQuery] DateTime end, [FromQuery] string patient)
        {
            return await _context.Appointments.Where(e => (e.Status == "free" || (e.Status != "free" && e.PatientId == patient)) && !((e.End <= start) || (e.Start >= end))).ToListAsync();
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentSlot>> GetAppointmentSlot(int id)
        {
            var appointmentSlot = await _context.Appointments.FindAsync(id);

            if (appointmentSlot == null)
            {
                return NotFound();
            }

            return appointmentSlot;
        }

        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointmentSlot(int id, AppointmentSlotUpdate update)
        {
            var appointmentSlot = await _context.Appointments.FindAsync(id);
            if (appointmentSlot == null)
            {
                return NotFound();
            }

            appointmentSlot.Start = update.Start;
            appointmentSlot.End = update.End;

            if (update.Name != null)
            {
                appointmentSlot.PatientName = update.Name;
            }

            if (update.Status != null)
            {
                appointmentSlot.Status = update.Status;
            }

            _context.Appointments.Update(appointmentSlot);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        public class AppointmentSlotUpdate
        {
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
            public string? Name { get; set; }
            public string? Status { get; set; }

        }


        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/request")]
        public async Task<IActionResult> PutAppointmentSlotRequest(int id, AppointmentSlotRequest slotRequest)
        {
            var appointmentSlot = await _context.Appointments.FindAsync(id);
            if (appointmentSlot == null)
            {
                return NotFound();
            }

            appointmentSlot.PatientName = slotRequest.Name;
            appointmentSlot.PatientId = slotRequest.Patient;
            appointmentSlot.Status = "waiting";

            _context.Appointments.Update(appointmentSlot);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        public class AppointmentSlotRequest
        {
            public string Patient { get; set; }
            public string Name { get; set; }

        }

        // POST: api/Appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        //Создание записи
        [HttpPost]
        public async Task<ActionResult<AppointmentSlot>> PostAppointmentSlot(AppointmentSlot appointmentSlot)
        {
            _context.Appointments.Add(appointmentSlot);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppointmentSlot", new { id = appointmentSlot.Id}, appointmentSlot);
        }

        [HttpPost("create")]
        public async Task<ActionResult<AppointmentSlot>> PostAppointmentSlots(AppointmentSlotRange range)
        {
            var existing = await _context.Appointments.Where(e => !((e.End <= range.Start) || (e.Start >= range.End))).ToListAsync();
            var slots = Timeline.GenerateSlots(range.Start, range.End, range.Weekends);
            slots.ForEach(slot =>
            {
                var overlaps = existing.Any(e => !((e.End <= slot.Start) || (e.Start >= slot.End)));
                if (overlaps)
                {
                    return;
                }
                _context.Appointments.Add(slot);
            });

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("clear")]
        public async Task<ActionResult<AppointmentSlot>> PostAppointmentClear(ClearRange range)
        {
            var start = range.Start;
            var end = range.End;

            _context.Appointments.RemoveRange(_context.Appointments.Where(e => e.Status == "free" && !((e.End <= start) || (e.Start >= end))));
            await _context.SaveChangesAsync();

            return NoContent();
        }


        public class ClearRange
        {
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
        }

        public class AppointmentSlotRange
        {
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
            public bool Weekends { get; set; }
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointmentSlot(int id)
        {
            var appointmentSlot = await _context.Appointments.FindAsync(id);
            if (appointmentSlot == null)
            {
                return NotFound();
            }

            _context.Appointments.Remove(appointmentSlot);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppointmentSlotExists(int id)
        {
            return _context.Appointments.Any(e => e.Id == id);
        }
    }
}

