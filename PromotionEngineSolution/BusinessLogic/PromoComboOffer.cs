using System;
using System.Collections.Generic;
using System.Linq;
using PromotionEngineSolution.Interfaces;
using PromotionEngineSolution.Models;
using PromotionEngineSolution.Utilities;

namespace PromotionEngineSolution.BusinessLogic
{
    public class PromoComboOffer : IPromoScheme
    {
        PromoClass appliedPromotion;
        CheckoutClass recentProductCheckout;
        List<CheckoutClass> productCheckouts;

        public PromoComboOffer()
        {
        }

        public double CalculateProductPrice(List<CheckoutClass> productCheckoutList)
        {
            productCheckouts = new List<CheckoutClass>();

            double finalPrice = 0;


            try
            {
                string[] str = appliedPromotion.ProductCode.Split(';').ToArray();
                foreach (CheckoutClass item in productCheckoutList)
                {
                    if (str.Contains(item.PrdCode))
                    {
                        productCheckouts.Add(item);
                        item.IsValid = true;
                    }
                }

                int quantity_first = 0;
                int quantity_second = 0;
                if (productCheckouts.Count > 1)
                {
                    quantity_first = productCheckouts[0].Quantity;
                    quantity_second = productCheckouts[1].Quantity;
                }
                //if one of the product quatity is empty
                if (quantity_first == 0 || quantity_second == 0)
                {
                    return recentProductCheckout.DefaultPrice;

                }

                //if both of the products are equal is size
                if (quantity_first == quantity_second)
                {
                    finalPrice = appliedPromotion.Price * quantity_first;
                }
                else if (quantity_first > quantity_second)
                {
                    int additionalItems = quantity_first - quantity_second;
                    finalPrice = (recentProductCheckout.DefaultPrice * additionalItems) + (appliedPromotion.Price * quantity_second);
                }
                else if (quantity_first < quantity_second)
                {
                    int additionalItems = quantity_second - quantity_first;
                    finalPrice = (recentProductCheckout.DefaultPrice * additionalItems) + (appliedPromotion.Price * quantity_first);
                }
            }
            catch (ArithmeticException ex)
            {
                LogWriter.LogWrite("Error in ComboOffer :" + ex.Message);
            }
            catch (Exception e)
            {
                LogWriter.LogWrite("Error in ComboOffer :" + e.Message);
            }

            return finalPrice;
        }

        public bool CanExecute(CheckoutClass product, List<PromoClass> promotions)
        {
            recentProductCheckout = product;
            appliedPromotion = promotions.Where(x => x.ProductCode.Split(';').Contains(product.ProdCode)).FirstOrDefault();
            if (appliedPromotion != null && !product.IsValid && appliedPromotion.PromoType == PromotionType.Combo)
            {
                return true;
            }

            return false;
        }
    }
}
