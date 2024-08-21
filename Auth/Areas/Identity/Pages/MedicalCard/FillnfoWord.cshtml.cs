using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using Syncfusion.DocIORenderer;
using Auth.Services;
using Hospital.Models;
using Microsoft.CodeAnalysis.Differencing;
using System.Numerics;
using Auth.Models;
using System.Security.Claims;

namespace Auth.Areas.Identity.Pages.MedicalCard
{
    public class FillnfoWordModel : PageModel
    {
		private readonly IWebHostEnvironment _hostingEnvironment;

        private readonly ApplicationDBContext _context;

        public ApplicationUser Doctor { get; set; }

        public string Heading { get; set; } = "Initial heading";

		public string Id { get; set; }

        public string Iddoctor { get; set; }

        public FillnfoWordModel(IWebHostEnvironment hostingEnvironment, ApplicationDBContext context)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }

        public IActionResult OnGet(string id)
        {
            Doctor = _context.Medics.FirstOrDefault(d => d.Id == id);
            Iddoctor = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Page();
        }

		public void OnPost(string id)
		{ 
			var medic = _context.Medics.Find(id);

			string path1 = Path.Combine(_hostingEnvironment.WebRootPath, "Data");

			string filePath1 = Path.Combine(path1, $"{medic.Id}.docx");

			if (!System.IO.File.Exists(filePath1))
			{
				WordDocument document = new WordDocument();
				WSection section = document.AddSection() as WSection;
				section.PageSetup.Margins.All = 72;
				section.PageSetup.PageSize = new Syncfusion.Drawing.Size(612, 792);

				WParagraphStyle style = document.AddParagraphStyle("Normal") as WParagraphStyle;
				style.CharacterFormat.FontName = "Calibri";
				style.CharacterFormat.FontSize = 11f;
				style.ParagraphFormat.BeforeSpacing = 0;
				style.ParagraphFormat.AfterSpacing = 8;
				style.ParagraphFormat.LineSpacing = 13.8f;

				style = document.AddParagraphStyle("Heading 1") as WParagraphStyle;

				style.ApplyBaseStyle("Normal");

				style.CharacterFormat.FontName = "Times New Roman";
				style.CharacterFormat.FontSize = 14f;
				style.CharacterFormat.TextColor = Syncfusion.Drawing.Color.Black;
				style.ParagraphFormat.BeforeSpacing = 12;
				style.ParagraphFormat.AfterSpacing = 0;
				style.ParagraphFormat.Keep = true;
				style.ParagraphFormat.KeepFollow = true;

				style.ParagraphFormat.KeepFollow = true;
				style.ParagraphFormat.OutlineLevel = Syncfusion.DocIO.OutlineLevel.Level1;

				IWParagraph paragraph = section.HeadersFooters.Header.AddParagraph();
				IWPicture picture;

				paragraph.ApplyStyle("Normal");
				paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Left;
				WTextRange textRange = paragraph.AppendText("") as WTextRange;
				textRange.CharacterFormat.FontSize = 12f;
				textRange.CharacterFormat.FontName = "Times New Roman";
				textRange.CharacterFormat.TextColor = Syncfusion.Drawing.Color.Red;


				//Appends paragraph.
				paragraph = section.AddParagraph();
				paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Left;
				textRange = paragraph.AppendText("Підпис: _________________________________\n______________________________________") as WTextRange;
				textRange.CharacterFormat.FontSize = 14f;
				textRange.CharacterFormat.FontName = "Times New Roman";

				paragraph = section.AddParagraph();
				paragraph = section.AddParagraph();
				paragraph = section.AddParagraph();
				paragraph = section.AddParagraph();
				paragraph = section.AddParagraph();

				//Appends paragraph.
				paragraph = section.AddParagraph();
				paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
				textRange = paragraph.AppendText("Пацієнт\nМедична картка") as WTextRange;
				textRange.CharacterFormat.FontSize = 20f;
				textRange.CharacterFormat.FontName = "Times New Roman";

				paragraph = section.AddParagraph();

				paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
				textRange = paragraph.AppendText("Ідентифікація пацієнта - ") as WTextRange;
				textRange.CharacterFormat.FontSize = 14f;
				textRange.CharacterFormat.FontName = "Times New Roman";

				paragraph = section.AddParagraph();
				paragraph = section.AddParagraph();
				paragraph = section.AddParagraph();

				paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Left;
				textRange = paragraph.AppendText("Прізвище:\nІм'я, Ім'я по батькові: \nДата народження:                                 Стать (Чоловік/Жінка) \nАдреса: \nНомер телефону:") as WTextRange;
				textRange.CharacterFormat.FontSize = 14f;
				textRange.CharacterFormat.FontName = "Times New Roman";
				paragraph = section.AddParagraph();

				paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Left;
				textRange = paragraph.AppendText("\n\n\n\n\n") as WTextRange;
				textRange.CharacterFormat.FontSize = 14f;
				textRange.CharacterFormat.FontName = "Times New Roman";
				paragraph = section.AddParagraph();

				paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Right;
				textRange = paragraph.AppendText("\nДата створення документа") as WTextRange;
				textRange.CharacterFormat.FontSize = 14f;
				textRange.CharacterFormat.FontName = "Times New Roman";
				paragraph = section.AddParagraph();

				//Appends paragraph.
				/*
				//Appends paragraph.
				paragraph = table[2, 0].AddParagraph();
				paragraph.ApplyStyle("Heading 1");
				paragraph.ParagraphFormat.LineSpacing = 12f;
				//Appends picture to the paragraph.
				FileStream image3 = new FileStream("wwwroot/Data/123.png", FileMode.Open, FileAccess.Read);
				picture = paragraph.AppendPicture(image3);
				picture.TextWrappingStyle = TextWrappingStyle.TopAndBottom;
				picture.VerticalOrigin = VerticalOrigin.Paragraph;
				picture.VerticalPosition = 3.75f;
				picture.HorizontalOrigin = HorizontalOrigin.Column;
				picture.HorizontalPosition = -5f;
				picture.WidthScale = 92;
				picture.HeightScale = 92;
				*/


				document.EnsureMinimal();
				document.LastSection.PageSetup.Margins.All = 72; paragraph = document.LastParagraph;
				paragraph.AppendText("Зміст");
				paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
				paragraph.ApplyStyle(BuiltinStyle.Heading4);
				paragraph = document.LastSection.AddParagraph() as WParagraph;
				paragraph = document.LastSection.AddParagraph() as WParagraph;

				TableOfContent toc = paragraph.AppendTOC(1, 2);
				section = document.LastSection;
				WParagraph newPara = section.AddParagraph() as WParagraph;
				newPara.AppendBreak(BreakType.PageBreak);
				AddHeading(section, BuiltinStyle.Heading1, "Документ із вбудованими стилями", "");
				AddHeading(section, BuiltinStyle.Heading2, "Хронологічний запис", "ssss");

				section = document.AddSection() as WSection;
				section.PageSetup.Margins.All = 72;
				section.BreakCode = SectionBreakCode.NewPage;
				AddHeading(section, BuiltinStyle.Heading2, "Звіт про результати розслідування", "sss");

				section = document.AddSection() as WSection;
				section.PageSetup.Margins.All = 72;
				section.BreakCode = SectionBreakCode.NewPage;
				AddHeading(section, BuiltinStyle.Heading2, "Запис про прийом ліків", "sss");

				section = document.AddSection() as WSection;
				section.PageSetup.Margins.All = 72;
				section.BreakCode = SectionBreakCode.NewPage;
				AddHeading(section, BuiltinStyle.Heading2, "Хірургічні та процедурні записи", "ssss");

				section = document.AddSection() as WSection;
				section.PageSetup.Margins.All = 72;
				section.BreakCode = SectionBreakCode.NewPage;
				AddHeading(section, BuiltinStyle.Heading2, "Запис про поточний стан здоров'я", "ssss");
				document.UpdateTableOfContents();

				MemoryStream stream = new MemoryStream();
				document.Save(stream, FormatType.Docx);
				stream.Position = 0;

				string path = Path.Combine(_hostingEnvironment.WebRootPath, "Data", $"{medic.Id}.docx");

				string filePath = Path.Combine(path, $"{medic.Id}.docx");

				if (!System.IO.File.Exists(filePath))
				{
					using (FileStream fileStream = new FileStream(path, FileMode.Create))
					{
						stream.CopyTo(fileStream);
					}
				}

				AddInfo(medic.Id);

				Response.Redirect($"/Identity/MedicalCard/FillnfoWord?id={medic.Id}");
			}
			else {
				AddInfo(medic.Id);
			}
		}

		private void AddHeading(WSection section, BuiltinStyle builtinStyle, string headingText, string paragraphText)
		{
			WParagraph paragraph = section.AddParagraph() as WParagraph;
			WTextRange text = paragraph.AppendText(headingText) as WTextRange;
			paragraph.ApplyStyle(builtinStyle);
			paragraph = section.AddParagraph() as WParagraph;
			paragraph.AppendText(paragraphText);
		}

		private void CreateDoc(string id) {
            var medic = _context.Medics.Find(id);

            string path1 = Path.Combine(_hostingEnvironment.WebRootPath, "Data");

            string filePath1 = Path.Combine(path1, $"{medic.Id}.docx");

            Doctor = _context.Medics.FirstOrDefault(d => d.Id == id);

            DateTime today = DateTime.Today;
            string formattedDate = today.ToString("dd MMMM yyyy");

            if (!System.IO.File.Exists(filePath1))
            {
                WordDocument document = new WordDocument();
                WSection section = document.AddSection() as WSection;
                section.PageSetup.Margins.All = 72;
                section.PageSetup.PageSize = new Syncfusion.Drawing.Size(612, 792);

                WParagraphStyle style = document.AddParagraphStyle("Normal") as WParagraphStyle;
                style.CharacterFormat.FontName = "Calibri";
                style.CharacterFormat.FontSize = 30f;
                style.ParagraphFormat.BeforeSpacing = 0;
                style.ParagraphFormat.AfterSpacing = 8;
                style.ParagraphFormat.LineSpacing = 13.8f;

                style = document.AddParagraphStyle("Heading 1") as WParagraphStyle;

                style.ApplyBaseStyle("Normal");

                style.CharacterFormat.FontName = "Times New Roman";
                style.CharacterFormat.FontSize = 41f;
                style.CharacterFormat.TextColor = Syncfusion.Drawing.Color.Black;
                style.ParagraphFormat.BeforeSpacing = 12;
                style.ParagraphFormat.AfterSpacing = 0;
                style.ParagraphFormat.Keep = true;
                style.ParagraphFormat.KeepFollow = true;

                style.ParagraphFormat.KeepFollow = true;
                style.ParagraphFormat.OutlineLevel = Syncfusion.DocIO.OutlineLevel.Level1;

                IWParagraph paragraph = section.HeadersFooters.Header.AddParagraph();
                IWPicture picture;

                paragraph.ApplyStyle("Normal");
                paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Left;
                WTextRange textRange = paragraph.AppendText("") as WTextRange;
                textRange.CharacterFormat.FontSize =34f;
                textRange.CharacterFormat.FontName = "Times New Roman";
                textRange.CharacterFormat.TextColor = Syncfusion.Drawing.Color.Red;


                //Appends paragraph.
                paragraph = section.AddParagraph();
                paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Left;
                textRange = paragraph.AppendText("Підпис: _________________________________\n______________________________________") as WTextRange;
                textRange.CharacterFormat.FontSize = 34f;
                textRange.CharacterFormat.FontName = "Times New Roman";

                paragraph = section.AddParagraph();
                paragraph = section.AddParagraph();
                paragraph = section.AddParagraph();
                paragraph = section.AddParagraph();
                paragraph = section.AddParagraph();

                //Appends paragraph.
                paragraph = section.AddParagraph();
                paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
                textRange = paragraph.AppendText("Пацієнт\nМедична картка") as WTextRange;
                textRange.CharacterFormat.FontSize = 62f;
                textRange.CharacterFormat.FontName = "Times New Roman";

                paragraph = section.AddParagraph();

                paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
                textRange = paragraph.AppendText($"Ідентифікація пацієнта - {id}") as WTextRange;
                textRange.CharacterFormat.FontSize = 41f;
                textRange.CharacterFormat.FontName = "Times New Roman";

                paragraph = section.AddParagraph();
                paragraph = section.AddParagraph();
                paragraph = section.AddParagraph();

                paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Left;
                textRange = paragraph.AppendText($"Прізвище:{Doctor.LastName}\nІм'я:{Doctor.FirtsName}, Ім'я по батькові:{Doctor.Patronymic} \nДата народження:{Doctor.DateOfBirth}                                 Gender(Male/Female) \nAdress:{Doctor.Address}\nTelephone number:{Doctor.PhoneNumber}") as WTextRange;
                textRange.CharacterFormat.FontSize = 41f;
                textRange.CharacterFormat.FontName = "Times New Roman";
                paragraph = section.AddParagraph();

                paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Left;
                textRange = paragraph.AppendText("\n\n\n\n\n") as WTextRange;
                textRange.CharacterFormat.FontSize = 41f;
                textRange.CharacterFormat.FontName = "Times New Roman";
                paragraph = section.AddParagraph();

                paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Right;
                textRange = paragraph.AppendText($"\nДата створення документа:{formattedDate}") as WTextRange;
                textRange.CharacterFormat.FontSize = 41f;
                textRange.CharacterFormat.FontName = "Times New Roman";
                paragraph = section.AddParagraph();

                //Appends paragraph.
                /*
				//Appends paragraph.
				paragraph = table[2, 0].AddParagraph();
				paragraph.ApplyStyle("Heading 1");
				paragraph.ParagraphFormat.LineSpacing = 12f;
				//Appends picture to the paragraph.
				FileStream image3 = new FileStream("wwwroot/Data/123.png", FileMode.Open, FileAccess.Read);
				picture = paragraph.AppendPicture(image3);
				picture.TextWrappingStyle = TextWrappingStyle.TopAndBottom;
				picture.VerticalOrigin = VerticalOrigin.Paragraph;
				picture.VerticalPosition = 3.75f;
				picture.HorizontalOrigin = HorizontalOrigin.Column;
				picture.HorizontalPosition = -5f;
				picture.WidthScale = 92;
				picture.HeightScale = 92;
				*/


                document.EnsureMinimal();
                document.LastSection.PageSetup.Margins.All = 72; paragraph = document.LastParagraph;
                paragraph.AppendText("Зміст");
                paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
                paragraph.ApplyStyle(BuiltinStyle.Heading4);
                paragraph = document.LastSection.AddParagraph() as WParagraph;
                paragraph = document.LastSection.AddParagraph() as WParagraph;

                TableOfContent toc = paragraph.AppendTOC(1, 2);
                section = document.LastSection;
                WParagraph newPara = section.AddParagraph() as WParagraph;
                newPara.AppendBreak(BreakType.PageBreak);
                AddHeading(section, BuiltinStyle.Heading1, "Документ із вбудованими стилями", "");
                AddHeading(section, BuiltinStyle.Heading2, "Chronological Record", "");

                section = document.AddSection() as WSection;
                section.PageSetup.Margins.All = 72;
                section.BreakCode = SectionBreakCode.NewPage;
                AddHeading(section, BuiltinStyle.Heading2, "Звіт про результати розслідування", "");

                section = document.AddSection() as WSection;
                section.PageSetup.Margins.All = 72;
                section.BreakCode = SectionBreakCode.NewPage;
                AddHeading(section, BuiltinStyle.Heading2, "Запис про прийом ліків", "");

                section = document.AddSection() as WSection;
                section.PageSetup.Margins.All = 72;
                section.BreakCode = SectionBreakCode.NewPage;
                AddHeading(section, BuiltinStyle.Heading2, "Хірургічні та процедурні записи", "");

                section = document.AddSection() as WSection;
                section.PageSetup.Margins.All = 72;
                section.BreakCode = SectionBreakCode.NewPage;
                AddHeading(section, BuiltinStyle.Heading2, "Запис про поточний стан здоров'я", "");
                document.UpdateTableOfContents();

                MemoryStream stream = new MemoryStream();
                document.Save(stream, FormatType.Docx);
                stream.Position = 0;

                string path = Path.Combine(_hostingEnvironment.WebRootPath, "Data", $"{medic.Id}.docx");

                string filePath = Path.Combine(path, $"{medic.Id}.docx");

                if (!System.IO.File.Exists(filePath))
                {
                    using (FileStream fileStream = new FileStream(path, FileMode.Create))
                    {
                        stream.CopyTo(fileStream);
                    }
                }
            
            }
            else
            {

            }
        }


		public void AddInfo(string id)
		{
			using (WordDocument document = new WordDocument())
			{
				using (FileStream stream = new FileStream(Path.Combine(_hostingEnvironment.WebRootPath, "Data", $"{id}.docx"), FileMode.Open, FileAccess.Read))
				{
					document.Open(stream, FormatType.Docx);
				}

				WSection section = document.Sections[3];
				WParagraph paragraph = section.Body.Paragraphs[1];

				paragraph.AppendText("Нова інформація для розділу 3, параграфа 1.");

				string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Data", $"{id}.docx");
				using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
				{
					document.Save(fileStream, FormatType.Docx);
				}

				MemoryStream docxStream = new MemoryStream();
				using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
				{
					fileStream.CopyTo(docxStream);
				}

				string htmlFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "Data", $"{id}.html");
				using (WordDocument document1 = new WordDocument(docxStream, FormatType.Docx))
				{
					using (FileStream htmlFileStream = new FileStream(htmlFilePath, FileMode.Create))
					{
						document1.Save(htmlFileStream, FormatType.Html);
                    }
				}
                Response.Redirect($"/Identity/MedicalCard/FillnfoWord?id={id}");
            }
		}

        public void OnPostAddInfoFirstTab(string id, string iddoctor, string typeOfInvestigation, string results, string referenceRanges, string interpretation ,string extraInformation)
        {
			CreateDoc(id);
            using (WordDocument document = new WordDocument())
            {
                using (FileStream stream = new FileStream(Path.Combine(_hostingEnvironment.WebRootPath, "Data", $"{id}.docx"), FileMode.Open, FileAccess.Read))
                {
                    document.Open(stream, FormatType.Docx);
                }

                DateTime today = DateTime.Today;
                string formattedDate = today.ToString("dd MMMM yyyy");

                WSection section = document.Sections[1];
                WParagraph paragraph = section.Body.Paragraphs[1];


				paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Left;
				paragraph.AppendText("\n");
				paragraph.AppendText($"\nІдентифікатор лікаря{iddoctor} - Дані {formattedDate}");
				paragraph.AppendText($"\n	Тип розслідування: {typeOfInvestigation}");
                paragraph.AppendText($"\n	Результати: {results}");
                paragraph.AppendText($"\n	Еталонні діапазони: {referenceRanges}");
                paragraph.AppendText($"\n	Усний переклад: {interpretation}");
                paragraph.AppendText($"\n	Додаткова інформація: {extraInformation}");



                string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Data", $"{id}.docx");
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    document.Save(fileStream, FormatType.Docx);
                }

                MemoryStream docxStream = new MemoryStream();
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    fileStream.CopyTo(docxStream);
                }

                string htmlFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "Data", $"{id}.html");
                using (WordDocument document1 = new WordDocument(docxStream, FormatType.Docx))
                {
                    using (FileStream htmlFileStream = new FileStream(htmlFilePath, FileMode.Create))
                    {
                        document1.Save(htmlFileStream, FormatType.Html);
                    }
                }
                RedirectToPage("/Index");
            }
        }

        public void OnPostAddInfoSecondTab(string id, string iddoctor, string medicationame, string dosage, string frequencyofadministration, string durationofadministration, string extrainformation)
        {
            CreateDoc(id);
            using (WordDocument document = new WordDocument())
            {
                using (FileStream stream = new FileStream(Path.Combine(_hostingEnvironment.WebRootPath, "Data", $"{id}.docx"), FileMode.Open, FileAccess.Read))
                {
                    document.Open(stream, FormatType.Docx);
                }

                DateTime today = DateTime.Today;
                string formattedDate = today.ToString("dd MMMM yyyy");

                WSection section = document.Sections[2];
                WParagraph paragraph = section.Body.Paragraphs[1];


                paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Left;
                paragraph.AppendText("\n");
                paragraph.AppendText($"\nІдентифікатор лікаря {iddoctor} - Дані {formattedDate}");
                paragraph.AppendText($"\n	Назва лікарського засобу: {medicationame}");
                paragraph.AppendText($"\n	Дозування: {dosage}");
                paragraph.AppendText($"\n	Частота застосування: {frequencyofadministration}");
                paragraph.AppendText($"\n	Тривалість адміністрування: {durationofadministration}");
                paragraph.AppendText($"\n	Додаткова інформація: {extrainformation}");



                string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Data", $"{id}.docx");
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    document.Save(fileStream, FormatType.Docx);
                }

                MemoryStream docxStream = new MemoryStream();
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    fileStream.CopyTo(docxStream);
                }

                string htmlFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "Data", $"{id}.html");
                using (WordDocument document1 = new WordDocument(docxStream, FormatType.Docx))
                {
                    using (FileStream htmlFileStream = new FileStream(htmlFilePath, FileMode.Create))
                    {
                        document1.Save(htmlFileStream, FormatType.Html);
                    }
                }
                RedirectToPage("/Index");
            }
        }
    }
}
