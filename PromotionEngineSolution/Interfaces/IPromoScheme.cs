using System;
using System.Collections.Generic;
using PromotionEngineSolution.Models;

namespace PromotionEngineSolution.Interfaces
{
    public interface IPromoScheme
    {
        bool CanExecute(CheckoutClass product, List<PromoClass> promotions);
        double CalculateProductPrice(List<CheckoutClass> productCheckoutList);
    }
}
