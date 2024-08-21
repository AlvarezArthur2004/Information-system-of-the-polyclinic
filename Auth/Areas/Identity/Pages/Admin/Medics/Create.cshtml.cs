using Auth.Models;
using Auth.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Auth.Areas.Identity.Pages.Admin.Products
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDBContext context;
        private readonly UserManager<ApplicationUser> _userManager;
        public void OnGet()
        {
        }

        [BindProperty]
        public ApplicationUserDto MedicDto { get; set; } = new ApplicationUserDto();

        public CreateModel(IWebHostEnvironment environment, ApplicationDBContext context, UserManager<ApplicationUser> userManager)
        {
            this.environment = environment;
            this.context = context;
            _userManager = userManager;
        }

        public string errorMessage = "";
        public string successMessage = "";

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                errorMessage = "Please provide all the required fields";
                return Page();
            }

            var existingUser = await _userManager.FindByEmailAsync(MedicDto.Email);
            if (existingUser != null)
            {
                errorMessage = "User with this email already exists";
                return Page();
            }

            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileName += Path.GetExtension(MedicDto.ImageFile!.FileName);

            string imageFullPath = environment.WebRootPath + "/photos/" + newFileName;

            using (var stream = System.IO.File.Create(imageFullPath))
            {
                MedicDto.ImageFile.CopyTo(stream);
            }


            ApplicationUser medic = new ApplicationUser()
            {
                FirtsName = MedicDto.FirtsName ?? "",
                LastName = MedicDto.LastName ?? "",
                Patronymic = MedicDto.Patronymic,
                Email = MedicDto.Email ?? "",
                PhoneNumber = MedicDto.PhoneNumber,
                Gender = MedicDto.Gender,
                WorkPlace = MedicDto.WorkPlace,
                Specialization = MedicDto.Specialization,
                DateOfBirth = MedicDto.DateOfBirth,
                Description = MedicDto.Description ?? "",
                ImageFileName = newFileName,
                UserName = MedicDto.Email ?? ""
            };

            var result = await _userManager.CreateAsync(medic, MedicDto.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    errorMessage = $"Error creating user: {error.Description}";
                }
                return Page();
            }

            await _userManager.AddToRoleAsync(medic, "seller");
            context.SaveChanges();

            MedicDto.PhoneNumber = "";
            MedicDto.LastName = "";
            MedicDto.Patronymic = "";
            MedicDto.Gender = "";
            MedicDto.WorkPlace = "";
            MedicDto.Specialization = "";
            MedicDto.DateOfBirth = DateTime.MinValue;
            MedicDto.Email = "";
            MedicDto.Description = "";
            MedicDto.ImageFile = null;
            MedicDto.Email = "";
            MedicDto.Password = "";
            ModelState.Clear();

            successMessage = "Medic created successfully";

            return RedirectToPage("/Admin/Medics/Index");
        }
    }
}
