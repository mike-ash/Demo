using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi_Webshop.services
{
    public interface IFinanceService
    {
        double CalculateTax(double price);
        double Tax { get; }
    }
}
