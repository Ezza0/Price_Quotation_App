using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Price_Quotation_App.Data;
using Price_Quotation_App.Models;

namespace Price_Quotation_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly PriceQuotationContext _context;

        public HomeController(PriceQuotationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? slug)
        {
            var form = new PriceQuotationModel();

            if (!string.IsNullOrWhiteSpace(slug))
            {
                var selectedQuote = await _context.PriceQuotes
                    .FirstOrDefaultAsync(quote => quote.Slug == slug);

                if (selectedQuote == null)
                {
                    return NotFound();
                }

                form.Subtotal = selectedQuote.Subtotal;
                form.DiscountPercent = selectedQuote.DiscountPercent;
            }

            return View(await BuildPageAsync(form));
        }

        [HttpPost]
        public async Task<IActionResult> Index(
            [Bind(Prefix = "Quote")] PriceQuotationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(await BuildPageAsync(model));
            }

            var savedQuote = new PriceQuote
            {
                Slug = $"quote-{Guid.NewGuid():N}",
                Subtotal = model.Subtotal!.Value,
                DiscountPercent = model.DiscountPercent!.Value,
                DiscountAmount = model.DiscountAmount,
                Total = model.Total,
                CreatedAtUtc = DateTime.UtcNow
            };

            _context.PriceQuotes.Add(savedQuote);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new { slug = savedQuote.Slug });
        }

        private async Task<PriceQuotationPageViewModel> BuildPageAsync(
            PriceQuotationModel form)
        {
            return new PriceQuotationPageViewModel
            {
                Quote = form,
                PreviousQuotes = await _context.PriceQuotes
                    .OrderByDescending(quote => quote.CreatedAtUtc)
                    .ToListAsync()
            };
        }
    }
}
