using HarfBuzzSharp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using System.Reflection;

namespace Auth.Areas.Identity.Pages.MedicalCard
{
    public class MedCardPModel : PageModel
    {

        private readonly IMemoryCache _cache;

        public MedCardPModel(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        public string HtmlContent { get; private set; }

        public void OnGet(string id)
        {
            // Получаем или устанавливаем контент из кэша
            HtmlContent = _cache.GetOrCreate(id, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10); // Устанавливаем время жизни кэша
                return $"~/Data/{id}.html";
            });
        }

        public IActionResult ClearCache(string id)
        {
            // Удаляем элемент из кэша по ключу
            _cache.Remove(id);
            return RedirectToPage("/MedicalCard/MedCardP", new { id });
        }
    }
}
