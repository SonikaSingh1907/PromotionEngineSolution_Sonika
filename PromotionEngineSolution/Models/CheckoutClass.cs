using System;
namespace PromotionEngineSolution.Models
{
    public class CheckoutClass
    {
        public string PrdCode { get; set; }
        public int Quantity { get; set; }
        public double FinalPrice { get; set; }
        public double DefaultPrice { get; set; }
        public bool HasOffer { get; set; }
        public bool IsValid { get; set; }
        public string ProdCode { get; internal set; }
    }
}
