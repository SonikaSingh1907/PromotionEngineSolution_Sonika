using System;
using System.Collections.Generic;
using PromotionEngineSolution.Models;

namespace PromotionEngineSolution.Interfaces
{
    public interface IPromoUser
    {
        List<CheckoutClass> LoadUserInput();
        bool DisplayTotalPrice(OfferClass offer);
    }
}
