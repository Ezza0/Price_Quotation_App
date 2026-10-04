using System.Collections.Generic;

namespace Price_Quotation_App.Models
{
    public class PriceQuotationPageViewModel
    {
        public PriceQuotationModel Quote { get; set; } = new PriceQuotationModel();

        public List<PriceQuote> PreviousQuotes { get; set; } = new List<PriceQuote>();
    }
}   