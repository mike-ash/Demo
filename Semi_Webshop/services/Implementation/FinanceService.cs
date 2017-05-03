using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Semi_Webshop.services
{
    public class FinanceService : IFinanceService
    {
        public double CalculateTax(double price)
        {
            return Tax * price;
        }

        protected double? tax = null;

        public double Tax
        {
            get
            {
                if (!tax.HasValue)
                {
                    double taxAux;
                    if (double.TryParse(WebConfigurationManager.AppSettings["mike:tax"], out taxAux))
                        tax = taxAux;
                    else
                        tax = 0;
                }
                return tax.Value;
            }
        }

    }
}