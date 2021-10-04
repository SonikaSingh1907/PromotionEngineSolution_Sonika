using System;
using System.Collections.Generic;
using System.Linq;
using PromotionEngineSolution.Interfaces;
using PromotionEngineSolution.Models;
using PromotionEngineSolution.Utilities;

namespace PromotionEngineSolution.BusinessLogic
{
    public class PromoAdditionalOffer : IPromoScheme
    {
        private PromoClass appliedPromotion;
        private CheckoutClass ProductCheckout;

        public PromoAdditionalOffer()
        {
            appliedPromotion = new PromoClass();
            ProductCheckout = new CheckoutClass();
        }

        public double CalculateProductPrice(List<CheckoutClass> prodCheckoutLst)
        {
            double finalPrice = 0;
            try
            {
                int totalItems = ProductCheckout.Quantity / appliedPromotion.Quantity;
                int remainingItems = ProductCheckout.Quantity % appliedPromotion.Quantity;
                finalPrice = appliedPromotion.Price * totalItems + remainingItems * (ProductCheckout.DefaultPrice);

            }
            catch (ArithmeticException ex)
            {
                LogWriter.LogWrite("Error in AdditionalItemOffer :" + ex.Message);
            }
            catch (Exception e)
            {
                LogWriter.LogWrite("Error in AdditionalItemOffer :" + e.Message);
            }

            return finalPrice;
        }

        public bool CanExecute(CheckoutClass product, List<PromoClass> promotions)
        {
            ProductCheckout = product;
            appliedPromotion = promotions.Where(x => x.ProductCode == product.ProdCode).FirstOrDefault();
            if (appliedPromotion != null && appliedPromotion.PromoType == PromotionType.Single)
            {
                product.IsValid = true;
                return true;
            }

            return false;
        }
    }
}
