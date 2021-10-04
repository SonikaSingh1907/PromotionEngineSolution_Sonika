using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using PromotionEngineSolution.Utilities;

namespace PromotionEngineSolution
{
    public class PromoConfiguration
    {
        IConfiguration configuration;
        IConfigurationBuilder configurationBuilder;

        public PromoConfiguration()
        {
            try
            {
                var builder = configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(Constants.DataStore, false);

                configurationBuilder = (IConfigurationBuilder)builder.Build();
                configuration = builder.Build();
            }
            catch (UnauthorizedAccessException ex)
            {
                LogWriter.LogWrite("Error in Config file Loading :" + ex.Message);
            }
            catch (Exception ex)
            {

                LogWriter.LogWrite("Error in Config file Loading :" + ex.Message);
            }

        }
    }
}
