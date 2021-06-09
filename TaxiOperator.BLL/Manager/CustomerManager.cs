using System;
using System.Collections.Generic;
using System.Text;
using TaxiOperator.BLL.DAL;

namespace TaxiOperator.BLL.Manager
{
    public class CustomerManager
    {
        #region Static Methods

        public static Customer GetRandom()
        {
            return new Customer().GetRandom();
        }

        public static void SetVip(int id)
        {
            new Customer().SetVipCustomer(id);
        }

        #endregion

    }
}
