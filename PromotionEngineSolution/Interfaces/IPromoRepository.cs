using System;
using System.Collections.Generic;
using PromotionEngineSolution.Models;

namespace PromotionEngineSolution.Interfaces
{
    public interface IPromoRepository
    {
        List<ProductClass> GetAvilableProducts();
        List<PromoClass> GetProductOffers();
    }
}
