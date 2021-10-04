using System;
using PromotionEngineSolution.BusinessLogic;
using PromotionEngineSolution.Utilities;

namespace PromotionEngineSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                LogWriter.LogWrite("Promotion Engine is initialized : ");

                PromotionLogic facade = new PromotionLogic();


                facade.CheckoutProducts();

                facade.ApplyPromotion();

                facade.DisplayTotalPrice(); 

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite("Exception in Promotion Engine .... : " + ex.Message);
            }
        }
    }
}
