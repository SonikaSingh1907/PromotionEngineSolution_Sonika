using System;
using System.Collections.Generic;

namespace PromotionEngineSolution.Models
{
    public class OfferClass
    {
        public List<CheckoutClass> Checkouts { get; set; }
        public double TotalPrice { get; set; }
    }
}
