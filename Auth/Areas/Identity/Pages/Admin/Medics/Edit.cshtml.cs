using Auth.Models;
using Auth.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System;
using System.IO;
using System.Linq;

namespace Auth.Areas.Identity.Pages.Admin.Medics
{
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDBContext context;
        private readonly PasswordHasher<ApplicationUser> passwordHasher;
        private readonly CommentDbContext _contextcomment;

        [BindProperty]
        public ApplicationUserDto MedicDto { get; set; } = new ApplicationUserDto();
        public ApplicationUser Medic { get; set; } = new ApplicationUser();

        public string errorMessage = "";
        public string successMessage = "";

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public List<ApplicationUser> Medics { get; set; } = new List<ApplicationUser>();

        public EditModel(IWebHostEnvironment environment, ApplicationDBContext context, CommentDbContext contextcomment)
        {
            this.environment = environment;
            this.context = context;
            this.passwordHasher = new PasswordHasher<ApplicationUser>();
            _contextcomment = contextcomment;
        }

        public void OnGet(string id)
        {
            if (id == null)
            {
                Response.Redirect("/Identity/Admin/Medics/Index");
                return;
            }

            var medic = context.Medics.Find(id);
            if (medic == null)
            {
                Response.Redirect("/Identity/Admin/Medics/Index");
                return;
            }

            MedicDto.PhoneNumber = medic.PhoneNumber;
            MedicDto.FirtsName = medic.FirtsName;
            MedicDto.LastName = medic.LastName;
            MedicDto.Patronymic = medic.Patronymic;
            MedicDto.Gender = medic.Gender;
            MedicDto.WorkPlace = medic.WorkPlace;
            MedicDto.Specialization = medic.Specialization;
            MedicDto.DateOfBirth = medic.DateOfBirth;
            MedicDto.Email = medic.Email;
            MedicDto.Description = medic.Description;
            MedicDto.Password = medic.PasswordHash;

            Comments = _contextcomment.Comments.Where(c => c.MedicId == id).ToList();

            Medic = medic;

            Medics = context.Medics.ToList();
        }

        public void OnPost(string id)
        {
            if (id == null)
            {
                Response.Redirect("/Identity/Admin/Medics/Index");
                return;
            }

            if (!ModelState.IsValid)
            {
                errorMessage = "Please provide all the required fields";
                return;
            }

            var medic = context.Medics.Find(id);
            if (medic == null)
            {
                Response.Redirect("/Identity/Admin/Medics/Index");
                return;
            }

            // Проверка на уникальность электронной почты
            var existingMedicWithEmail = context.Medics.FirstOrDefault(m => m.Email == MedicDto.Email && m.Id != id);
            if (existingMedicWithEmail != null)
            {
                errorMessage = "Email is already in use";
                return;
            }

            // Проверка на уникальность номера телефона
            var existingMedicWithPhoneNumber = context.Medics.FirstOrDefault(m => m.PhoneNumber == MedicDto.PhoneNumber && m.Id != id);
            if (existingMedicWithPhoneNumber != null)
            {
                errorMessage = "Phone number is already in use";
                return;
            }

            string newFileName = "";
            if (MedicDto.ImageFile != null)
            {
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(MedicDto.ImageFile.FileName);

                string imageFullPath = Path.Combine(environment.WebRootPath, "photos", newFileName);

                using (var stream = new FileStream(imageFullPath, FileMode.Create))
                {
                    MedicDto.ImageFile.CopyTo(stream);
                }

                // Удаление старого изображения
                if (!string.IsNullOrEmpty(medic.ImageFileName))
                {
                    string oldImageFullPath = Path.Combine(environment.WebRootPath, "photos", medic.ImageFileName);
                    if (System.IO.File.Exists(oldImageFullPath))
                    {
                        System.IO.File.Delete(oldImageFullPath);
                    }
                }
            }
            else
            {
                // Если новое изображение не загружается, сохраняем имя существующего изображения
                newFileName = medic.ImageFileName ?? "";
            }

            // Обновление остальных данных доктора
            medic.PhoneNumber = MedicDto.PhoneNumber ?? "";
            medic.FirtsName = MedicDto.FirtsName ?? "";
            medic.LastName = MedicDto.LastName ?? "";
            medic.Patronymic = MedicDto.Patronymic;
            medic.Gender = MedicDto.Gender;
            medic.PasswordHash = MedicDto.Password;
            medic.WorkPlace = MedicDto.WorkPlace;
            medic.Specialization = MedicDto.Specialization;
            medic.DateOfBirth = MedicDto.DateOfBirth;
            medic.Email = MedicDto.Email ?? "";
            medic.Description = MedicDto.Description ?? "";
            medic.ImageFileName = newFileName;

            context.SaveChanges();

            successMessage = "Medic updated successfully";

            Response.Redirect("/Identity/Admin/Medics/Index");
        }
    }
}
