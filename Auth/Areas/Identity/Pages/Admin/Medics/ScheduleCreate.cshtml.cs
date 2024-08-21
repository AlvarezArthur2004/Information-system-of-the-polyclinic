using Auth.Controllers;
using Auth.Models;
using Auth.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Auth.Areas.Identity.Pages.Admin.Medics
{
    public class ScheduleCreateModel : PageModel
    {
        private readonly ApplicationDBContext context;

        private readonly AppointmentsController appointmentsController;

        public List<ApplicationUser> Medics { get; set; } = new List<ApplicationUser>();

        public ApplicationUser Medic { get; set; } = new ApplicationUser();

        public ScheduleCreateModel(ApplicationDBContext context, AppointmentsController appointmentsController)
        {
            this.context = context;
            this.appointmentsController = appointmentsController;
        }
        public void OnGet(string id)
        {
            Medic = context.Medics.Find(id);
        }
        /*
        public async Task<IActionResult> OnPostAsync(string doctorId)
        {
            var appointmentSlot = new AppointmentSlot();
            appointmentSlot.DoctorId = doctorId; // Устанавливаем идентификатор доктора

            // Вызываем метод PostAppointmentSlot и получаем результат
            var result = await appointmentsController.PostAppointmentSlot(appointmentSlot);

            // Проверяем, является ли результат типом ActionResult<AppointmentSlot>
            if (result is ActionResult<AppointmentSlot> actionResult)
            {
                // Извлекаем созданный объект AppointmentSlot из результата
                var createdSlot = actionResult.Value;

                // Если созданный объект AppointmentSlot не равен null
                if (createdSlot != null)
                {
                    // Используем созданный объект AppointmentSlot
                    var createdId = createdSlot.Id; // Получаем id созданной записи
                                                    // Здесь вы можете использовать созданный id, если это необходимо
                }
                else
                {
                    // Обработка случая, когда созданный объект AppointmentSlot равен null
                    // Например, возвращение соответствующего сообщения об ошибке или перенаправление на другую страницу
                    return RedirectToPage("/Error");
                }
            }
            else
            {
                // Обработка случая, когда результат вызова метода не является типом ActionResult<AppointmentSlot>
                // Например, возвращение соответствующего сообщения об ошибке или перенаправление на другую страницу
                return RedirectToPage("/Error");
            }

            // Редирект на страницу Index или куда угодно другое
            return RedirectToPage("./Index");
        }
        
        */

    }
}
