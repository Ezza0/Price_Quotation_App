using System.ComponentModel.DataAnnotations;

namespace Price_Quotation_App.Models
{
    public class PriceQuotationModel
    {
        [Required(ErrorMessage = "Please enter Subtotal amount.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Subtotal amount must be greater than zero.")]
        public decimal? Subtotal { get; set; }

        [Required(ErrorMessage = "Please enter Discount percent.")]
        [Range(0, 100, ErrorMessage = "Discount percent must be between 0 and 100.")]
        public decimal? DiscountPercent { get; set; }

        public decimal DiscountAmount => (Subtotal ?? 0) * (DiscountPercent ?? 0) / 100;

        public decimal Total => (Subtotal ?? 0) - DiscountAmount;

    }
}