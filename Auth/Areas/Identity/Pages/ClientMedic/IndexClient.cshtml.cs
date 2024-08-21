using Auth.Models;
using Auth.Services;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.CodeAnalysis.Differencing;

namespace Auth.Areas.Identity.Pages.ClientMedic
{
    public class IndexClientModel : PageModel
    {
        private readonly ApplicationDBContext context;

        //pagination functionallity
        public int pageIndex = 1;
        public int totalPages = 0;
        private readonly int pageSize = 12;

        //search functionality
        public string search = "";

        public string column = "Id";
        public string orderBy = "desc";

        private readonly ILogger<IndexClientModel> _logger;

        public List<ApplicationUser> Medics { get; set; } = new List<ApplicationUser>();

        public List<ApplicationUser> MedicsTemp { get; set; } = new List<ApplicationUser>();


        private readonly CommentDbContext _contextcomment;

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public string Check { get; set; } = "1";

        public IndexClientModel(ApplicationDBContext context, CommentDbContext contextcomment, ILogger<IndexClientModel> logger)
        {
            this.context = context;
            _contextcomment = contextcomment;
            _logger = logger;
        }
        public void OnGet(int? pageIndex, string? search, string? column, string? orderBy)
        {

            IQueryable<ApplicationUser> query = context.Medics;

            Comments = _contextcomment.Comments.ToList();

            bool a = false;

            //search functionallity
            if (search != null)
            {
                this.search = search;
                query = query.Where(p => p.FirtsName.Contains(search) || p.LastName.Contains(search) || p.Patronymic.Contains(search) || p.Specialization.Contains(search));
            }

            //sort functionality
            string[] validColumns = { "Id", "PhoneNumber", "FirstName", "LastName", "Price", "Patronymic", "Gender", "WorkPlace", "Specialization", "DateOfBirth", "Best", "Description", "Terapevt", "Hirurg", "Pediatr", "Nevrolog", "Dermatolog", "PlastichnyHirurg", "Ortoped", "FizichniTerapevt", "Psichyk", "Oftalmolog" };
            string[] validOrderBy = { "desc", "asc" };

            if (!validColumns.Contains(column))
            {
                column = "Id";
            }

            if (!validOrderBy.Contains(orderBy))
            {
                orderBy = "desc";
            }

            this.column = column;
            this.orderBy = orderBy;

            if (column == "Gender")
            {
                if (orderBy == "asc")
                {
                    query = query.OrderBy(p => p.Gender);
                }
                else
                {
                    query = query.OrderByDescending(p => p.Gender);
                }
            }
            else if (column == "Terapevt")
            {
                if (orderBy == "asc")
                {
                    query = query.Where(p => p.Specialization == "Терапевт");
                }
                else
                {
                    query = query.Where(p => p.Specialization == "Терапевт");
                }
            }
            else if (column == "Hirurg")
            {
                if (orderBy == "asc")
                {
                    query = query.Where(p => p.Specialization == "Хірург");
                }
                else
                {
                    query = query.Where(p => p.Specialization == "Хірург");
                }
            }
            else if (column == "Pediatr")
            {
                if (orderBy == "asc")
                {
                    query = query.Where(p => p.Specialization == "Педіатр");
                }
                else
                {
                    query = query.Where(p => p.Specialization == "Педіатр");
                }
            }
            else if (column == "Nevrolog")
            {
                if (orderBy == "asc")
                {
                    query = query.Where(p => p.Specialization == "Невролог");
                }
                else
                {
                    query = query.Where(p => p.Specialization == "Невролог");
                }
            }
            else if (column == "Dermatolog")
            {
                if (orderBy == "asc")
                {
                    query = query.Where(p => p.Specialization == "Дерматолог");
                }
                else
                {
                    query = query.Where(p => p.Specialization == "Дерматолог");
                }
            }            
            else if (column == "PlastichnyHirurg")
            {
                if (orderBy == "asc")
                {
                    query = query.Where(p => p.Specialization == "Пластичний хірург");
                }
                else
                {
                    query = query.Where(p => p.Specialization == "Пластичний хірург");
                }
            }
            else if (column == "Ortoped")
            {
                if (orderBy == "asc")
                {
                    query = query.Where(p => p.Specialization == "Ортопед");
                }
                else
                {
                    query = query.Where(p => p.Specialization == "Ортопед");
                }
            }
            else if (column == "FizichniTerapevt")
            {
                if (orderBy == "asc")
                {
                    query = query.Where(p => p.Specialization == "Фізичний терапевт");
                }
                else
                {
                    query = query.Where(p => p.Specialization == "Фізичний терапевт");
                }
            }
            else if (column == "Psichyk")
            {
                if (orderBy == "asc")
                {
                    query = query.Where(p => p.Specialization == "Психіатр");
                }
                else
                {
                    query = query.Where(p => p.Specialization == "Психіатр");
                }
            }
            else if (column == "Oftalmolog")
            {
                if (orderBy == "asc")
                {
                    query = query.Where(p => p.Specialization == "Офтальмолог");
                }
                else
                {
                    query = query.Where(p => p.Specialization == "Офтальмолог");
                }
            }
            else if (column == "Specialization")
            {
                if (orderBy == "asc")
                {
                    query = query.OrderBy(p => p.Specialization);
                }
                else
                {
                    query = query.OrderByDescending(p => p.Specialization);
                }
            }
            else if (column == "Best")
            {
                if (orderBy == "asc")
                {
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

                    myList = myList.OrderByDescending(m => m.Value2).ToList(); // Изменяем порядок сортировки на возрастающий

                    // Заполняем список idpopdoctor в том же порядке, в котором отсортированы медики в myList
                    for (int i = myList.Count - 1; i >= 0; i--)
                    {
                        idpopdoctor.Add(myList[i].Value1);
                    }

                    // Фильтруем query по отсортированным идентификаторам, а затем загружаем данные в память
                    var filteredMedics = query.Where(medic => idpopdoctor.Contains(medic.Id)).AsEnumerable();

                    // Сортируем список Medics на стороне приложения, используя локальную сортировку в обратном порядке
                    Medics = filteredMedics.OrderBy(medic => idpopdoctor.IndexOf(medic.Id)).ToList();

                    a = true;
                }
                else
                {
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

                    for (int i = 0; i < myList.Count(); i++)
                    {
                        idpopdoctor.Add(myList[i].Value1);
                    }

                    var filteredMedics = query.Where(medic => idpopdoctor.Contains(medic.Id)).AsEnumerable();

                    Medics = filteredMedics.OrderBy(medic => idpopdoctor.IndexOf(medic.Id)).ToList();

                    a = true;
                }
            }
            else
            {
                if (orderBy == "asc")
                {
                    query = query.OrderBy(p => p.Id);
                }
                else
                {
                    query = query.OrderByDescending(p => p.Id);
                }
            }

            // query = query.OrderByDescending(p => p.Id);
            
            //pagination functionallity
            if (pageIndex == null || pageIndex < 1)
            {
                pageIndex = 1;
            }

            this.pageIndex = (int)pageIndex;


            decimal count = query.Count();
            totalPages = (int)Math.Ceiling(count / pageSize);
            query = query.Skip((this.pageIndex - 1) * pageSize)
                .Take(pageSize);

            if (a == false)
                Medics = query.Where(medic => medic.Specialization != null && medic.Specialization != "" && medic.Specialization != string.Empty).ToList();

            Comments = _contextcomment.Comments.ToList();
        }
    }
}

public struct MyStruct
{
    public string Value1;
    public int Value2;
}