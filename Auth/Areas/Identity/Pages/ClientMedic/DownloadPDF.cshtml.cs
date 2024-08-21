using Auth.Models;
using Auth.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Hospital.Models;

namespace Auth.Areas.Identity.Pages.ClientMedic
{
    public class DownloadPDFModel : PageModel
    {

        private readonly ApplicationDBContext _context;
        private readonly DoctorDbContext _contextSchedule;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AppointmentSlot Schedule { get; set; }
        public ApplicationUser Doctor { get; set; }
        public string SlotIdOut { get; set; }

        public DownloadPDFModel(ApplicationDBContext context, DoctorDbContext contextSchedule, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _contextSchedule = contextSchedule;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult OnGet(string id)
        {
            string wordFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "Data", $"{id}.docx");

            WordDocument wordDocument = new WordDocument();

            using (FileStream stream = new FileStream(wordFilePath, FileMode.Open, FileAccess.Read))
            {
                wordDocument.Open(stream, FormatType.Docx);
            }

            using (DocIORenderer renderer = new DocIORenderer())
            {
                PdfDocument pdfDocument = renderer.ConvertToPDF(wordDocument);

                string fileName = $"{id}.pdf";

                // Генерация временного пути и сохранение PDF-файла
                string tempFilePath = Path.Combine(Path.GetTempPath(), fileName);
                using (FileStream fileStream = new FileStream(tempFilePath, FileMode.Create))
                {
                    pdfDocument.Save(fileStream);
                }

                // Предоставление PDF-файла для скачивания
                byte[] pdfBytes = System.IO.File.ReadAllBytes(tempFilePath);
                return File(pdfBytes, "application/pdf", fileName);
            }
        }

    }
}
