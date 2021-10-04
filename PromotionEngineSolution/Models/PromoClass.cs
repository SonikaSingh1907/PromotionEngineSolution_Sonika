using System;
namespace PromotionEngineSolution.Models
{
    public class PromoClass
    {
        public int PromoId { get; set; }
        public int Quantity { get; set; }
        public string PromoType { get; set; }
        public string ProductCode { get; set; }
        public double Price { get; set; }
    }
}
