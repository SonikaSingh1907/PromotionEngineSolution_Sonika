using System;
using System.Collections.Generic;
using PromotionEngineSolution.Models;

namespace PromotionEngineSolution.Interfaces
{
    public interface IPromoService
    {
        OfferClass ApplyPromotion(
            List<CheckoutClass> checkoutList, List<PromoClass> promotions);
    }
}
