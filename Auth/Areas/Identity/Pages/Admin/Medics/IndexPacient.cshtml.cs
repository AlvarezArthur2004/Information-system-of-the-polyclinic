using Auth.Models;
using Auth.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Auth.Areas.Identity.Pages.Admin.Medics
{
    public class IndexPacientModel : PageModel
    {
        private readonly ApplicationDBContext context;

        //pagination functionallity
        public int pageIndex = 1;
        public int totalPages = 0;
        private readonly int pageSize = 5;

        //search functionality
        public string search = "";

        public string column = "Id";
        public string orderBy = "desc";

        public List<ApplicationUser> Medics { get; set; } = new List<ApplicationUser>();

        public IndexPacientModel(ApplicationDBContext context)
        {
            this.context = context;
        }
        public void OnGet(int? pageIndex, string? search, string? column, string? orderBy)
        {
            IQueryable<ApplicationUser> query = context.Medics;

            //search functionallity
            if (search != null)
            {
                this.search = search;
                query = query.Where(p => p.FirtsName.Contains(search) || p.LastName.Contains(search) || p.Patronymic.Contains(search) || p.Specialization.Contains(search));
            }

            //sort functionality
            string[] validColumns = { "Id", "PhoneNumber", "FirstName", "LastName", "Price", "Patronymic", "Gender", "WorkPlace", "Specialization", "DateOfBirth", "Email", "Description", "CreatedAt" };
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
            else if (column == "WorkPlace")
            {
                if (orderBy == "asc")
                {
                    query = query.OrderBy(p => p.WorkPlace);
                }
                else
                {
                    query = query.OrderByDescending(p => p.WorkPlace);
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

            query = query.OrderBy(p => p.Specialization);

            decimal count = query.Count();
            totalPages = (int)Math.Ceiling(count / pageSize);
            query = query.Skip((this.pageIndex - 1) * pageSize)
                .Take(pageSize);

            Medics = query.Where(medic => medic.Specialization == "").ToList();
        }
    }
}

