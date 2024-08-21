using Auth.Models;
using Auth.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Auth.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly IWebHostEnvironment _hostingEnvironment;

        private readonly ApplicationDBContext _context;

        private readonly CommentDbContext _contextcomment;
        public List<ApplicationUser> Medics { get; set; } = new List<ApplicationUser>();
        public List<Comment> Comments { get; set; } = new List<Comment>();

        public List<ApplicationUser> MedicsTemp { get; set; } = new List<ApplicationUser>();

        public IndexModel(ILogger<IndexModel> logger, ApplicationDBContext context, CommentDbContext contextcomment)
        {
            _logger = logger;
            _context = context;
            _contextcomment = contextcomment;
        }

        public void OnGet()
        {
            IQueryable<ApplicationUser> query = _context.Medics;

            Comments = _contextcomment.Comments.ToList();

            MedicsTemp = query.ToList();

            List<MyStruct> myList = new List<MyStruct>();

            List<string> idpopdoctor = new List<string>();
            foreach (var medic in MedicsTemp)
            {
                //Check += myList[i].Value1;


                double starkol = 0;
                double kol = 0;

                var medicComments = Comments.Where(c => c.MedicId == medic.Id);

                foreach (var comment in medicComments)
                {
                    starkol += Convert.ToInt32(comment.Rate);
                    kol++;
                }

                if (kol > 0)
                {
                    myList.Add(new MyStruct { Value1 = medic.Id, Value2 = Convert.ToInt32(Math.Ceiling(starkol / kol)) });
                }
            }


            myList = myList.OrderByDescending(m => m.Value2).ToList(); 

            for (int i = myList.Count - 1; i >= 0; i--)
            {
                idpopdoctor.Add(myList[i].Value1);
            }

            var filteredMedics = query.Where(medic => idpopdoctor.Contains(medic.Id)).AsEnumerable();

            Medics = filteredMedics.OrderBy(medic => idpopdoctor.IndexOf(medic.Id)).ToList();
        }
    }
}