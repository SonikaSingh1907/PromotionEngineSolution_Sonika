using System;
using System.Collections.Generic;
using PromotionEngineSolution.Interfaces;
using PromotionEngineSolution.Models;

namespace PromotionEngineSolution.BusinessLogic
{
    public class PromoUser : IPromoUser
    {
        PromoConfiguration configManagement;
        IPromoRepository promoRepository;

        public PromoUser()
        {
            configManagement = new PromoConfiguration();
            promoRepository = new PromoRepository();
        }

        public bool DisplayTotalPrice(OfferClass offer)
        {
            Console.WriteLine("Calculate Final Price");
            Console.WriteLine("ProductCode" + "-" + "Quantity" + " - " + "FinalPrice" + " - " + "HasOffer");
            foreach (var item in offer.Checkouts)
            {
                Console.WriteLine(item.ProdCode + "-" + item.Quantity + "-" + item.FinalPrice + "-" + item.HasOffer);
            }
            Console.WriteLine("Total Price : " + offer.TotalPrice);
            return true;
        }

        public List<CheckoutClass> LoadUserInput()
        {
            List<CheckoutClass> checkoutList = new List<CheckoutClass>();
            List<ProductClass> lstProduct = promoRepository.GetAvilableProducts();

            Console.WriteLine("Enter User Inputs");
            try
            {
                foreach (var item in lstProduct)
                {
                    Console.WriteLine("Input quantity of " + item.ProdCode);
                    int quantity = Convert.ToInt32(Console.ReadLine());

                    checkoutList.Add(new CheckoutClass()
                    {
                        ProdCode = item.ProdCode,
                        Quantity = quantity,
                        DefaultPrice = item.ProdPrice
                    });
                }

            }
            catch (FormatException ex)
            {

                Console.WriteLine("Error in User Entry: " + ex.Message);
            }
            catch (OverflowException ex)
            {

                Console.WriteLine("Error in User Entry: " + ex.Message);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error in User Entry: " + ex.Message);
            }
            return checkoutList;
        }
    }
}
