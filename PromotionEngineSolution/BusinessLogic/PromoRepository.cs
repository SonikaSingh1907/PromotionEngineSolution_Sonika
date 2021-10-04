using System;
using System.Collections.Generic;
using PromotionEngineSolution.Interfaces;
using PromotionEngineSolution.Models;
using PromotionEngineSolution.Utilities;
using Microsoft.Extensions.Configuration;

namespace PromotionEngineSolution.BusinessLogic
{
    public class PromoRepository : IPromoRepository
    {
        IConfiguration config;

        public PromoRepository()
        {
            PromoConfiguration configuration = new PromoConfiguration();
        }

        public List<ProductClass> GetAvilableProducts()
        {
            List<ProductClass> productList = new List<ProductClass>();
            var productConfig = config.GetSection(Constants.Products).GetChildren();

            foreach (var item in productConfig)
            {
                ProductClass product = new ProductClass();
                config.GetSection(item.Path).Bind(product);
                productList.Add(product);
            }

            return productList;
        }

        public List<PromoClass> GetProductOffers()
        {
            List<PromoClass> lst = new List<PromoClass>();
            var promoConfig = config.GetSection(Constants.Promotions).GetChildren();

            foreach (var item in promoConfig)
            {
                PromoClass product = new PromoClass();
                config.GetSection(item.Path).Bind(product);
                lst.Add(product);
            }
            return lst;
        }
    }
}
