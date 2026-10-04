namespace Price_Quotation_App.Models
{
    public class PriceQuote
    {
        public int Id { get; set; }
        public string Slug { get; set; } = string.Empty;
        public decimal Subtotal { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedAtUtc { get; set; }
    }
}