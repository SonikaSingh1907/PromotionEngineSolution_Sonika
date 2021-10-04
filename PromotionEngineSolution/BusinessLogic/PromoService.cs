using System;
using System.Collections.Generic;
using PromotionEngineSolution.Interfaces;
using PromotionEngineSolution.Models;
using PromotionEngineSolution.Utilities;

namespace PromotionEngineSolution.BusinessLogic
{
    public class PromoService : IPromoService
    {
        public PromoService()
        {
        }

        public OfferClass ApplyPromotion(List<CheckoutClass> checkoutList, List<PromoClass> promotions)
        {
            OfferClass appliedOffer = new OfferClass();

            //Here Strategy pattern allows a  to choose an algorithm from a family of Promotion algorithms 
            List<IPromoScheme> promoSchemes = new List<IPromoScheme>();
            promoSchemes.Add(new PromoAdditionalOffer());
            promoSchemes.Add(new PromoComboOffer());

            try
            {
                foreach (CheckoutClass item in checkoutList)
                {
                    if (item.Quantity > 0)
                    {
                        foreach (var strategy in promoSchemes)
                        {
                            if (strategy.CanExecute(item, promotions))
                            {
                                item.HasOffer = true;
                                item.FinalPrice = strategy.CalculateProductPrice(checkoutList);
                                appliedOffer.TotalPrice += item.FinalPrice;
                                break;
                            }
                        }
                    }
                }
                appliedOffer.Checkouts = checkoutList;
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite("Error in Applying Promotion in PromotionStrategy:" + ex.Message);
            }

            return appliedOffer;
        }
    }
}
