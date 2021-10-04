using System.Collections.Generic;
using NUnit.Framework;
using PromotionEngineSolution.BusinessLogic;
using PromotionEngineSolution.Interfaces;
using PromotionEngineSolution.Models;

namespace PromotionEngineSolution.Tests
{
    public class PromotionEngineTest
    {
        List<PromoClass> promotions;
        IPromoService promotionService;

        [SetUp]
        public void Setup()
        {
            promotionService = new PromoService();
            promotions = new List<PromoClass>() { new PromoClass() { PromoType = "Single", ProductCode = "A", Price = 130, Quantity = 3 }, new PromoClass() { PromoType = "Single", ProductCode = "B", Price = 45, Quantity = 2 }, new PromoClass() { PromoType = "Combo", ProductCode = "C;D", Price = 30, Quantity = 3 } };
        }

        /// <summary>
        /// Scenario A
        /// 1* A =50
        /// 1* B =30
        /// 1* C =20
        /// </summary>
        [Test]
        public void Promo_NoOfferTest()
        {
            List<CheckoutClass> orderCart = new List<CheckoutClass>() { new CheckoutClass() { PrdCode = "A", Quantity = 1, DefaultPrice = 50 }, new CheckoutClass() { PrdCode = "B", Quantity = 1, DefaultPrice = 30 }, new CheckoutClass() { PrdCode = "C", Quantity = 1, DefaultPrice = 20 } };
            double expectedValue = 100;
            double actualValue = promotionService.ApplyPromotion(orderCart, promotions).TotalPrice;
            Assert.AreEqual(expectedValue, actualValue);
        }

        /// <summary>
        /// Scenario B
        /// 5 * A =130 + 2*50
        /// 5 * B =45 + 45 + 30
        /// 1 * C =28
        //Total = 370 
        /// </summary>
        [Test]
        public void Promo_TwoOffer_Single_Test()
        {
            List<CheckoutClass> orderCart = new List<CheckoutClass>() { new CheckoutClass() { PrdCode = "A", Quantity = 5, DefaultPrice = 50 }, new CheckoutClass() { PrdCode = "B", Quantity = 5, DefaultPrice = 30 }, new CheckoutClass() { PrdCode = "C", Quantity = 1, DefaultPrice = 20 } };
            double expectedValue = 370;
            double actualValue = promotionService.ApplyPromotion(
                orderCart,
                promotions).TotalPrice;
            Assert.AreEqual(expectedValue, actualValue);
        }

        /// <summary>
        /// Scenario C
        /// 3* A =130
        /// 5* B =45 + 45 + 1 * 30
        /// 1* C =-
        /// 1* D =30
        /// </summary>
        [Test]
        public void Promo_TwoOffer_Combo_Test()
        {
            List<CheckoutClass> orderCart = new List<CheckoutClass>() { new CheckoutClass() { PrdCode = "A", Quantity = 3, DefaultPrice = 50 }, new CheckoutClass() { PrdCode = "B", Quantity = 5, DefaultPrice = 30 }, new CheckoutClass() { PrdCode = "C", Quantity = 1, DefaultPrice = 20 }, new CheckoutClass() { PrdCode = "D", Quantity = 1, DefaultPrice = 15 } };
            double expectedValue = 280;
            double actualValue = promotionService.ApplyPromotion(orderCart, promotions).TotalPrice;
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
