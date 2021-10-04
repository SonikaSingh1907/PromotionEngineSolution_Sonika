using System;
using System.Collections.Generic;
using PromotionEngineSolution.Interfaces;
using PromotionEngineSolution.Models;
using PromotionEngineSolution.Utilities;

namespace PromotionEngineSolution.BusinessLogic
{
    public class PromotionLogic
    {
        IPromoUser promoUser;
        IPromoService promoService;
        IPromoRepository promoRepository;

        public PromotionLogic()
        {
            promoUser = new PromoUser();
            promoService = new PromoService();
            promoRepository = new PromoRepository();
        }

        List<CheckoutClass> checkoutList;
        OfferClass appliedOffer;

        public bool CheckoutProducts()
        {
            try
            {
                checkoutList = promoUser.LoadUserInput();
                return true;
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite("Error in Checking out Products :" + ex.Message);
            }
            return false;
        }

        internal bool ApplyPromotion()
        {
            try
            {
                appliedOffer = promoService.ApplyPromotion(checkoutList, GetProductOffers());
                return true;
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite("Error in  Applying Promotio :" + ex.Message);
            }
            return false;
        }

        public bool DisplayTotalPrice()
        {
            try
            {
                if (appliedOffer.Checkouts != null)
                {
                    promoUser.DisplayTotalPrice(appliedOffer);
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite("Error in  Displaying TotalPrice:" + ex.Message);
            }

            return false;
        }

        public List<PromoClass> GetProductOffers()
        {
            try
            { 
                return promoRepository.GetProductOffers();
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite("Error in Getting Product Offers :" + ex.Message);
            }
            return new List<PromoClass>();
        }

        public List<ProductClass> GetAvilableProducts()
        {
            try
            {
                return promoRepository.GetAvilableProducts();
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite("Error in Getting AvilableProducts :" + ex.Message);

            }
            return new List<ProductClass>();
        }
    }
}
