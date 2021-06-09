using System.Collections.Generic;
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

        public static List<Customer> GetList()
        {
            return new Customer().GetList();
        }

        public static void Save(Customer customer)
        {
            if (customer.Id > 0)
            {
                customer.Update();
            }
            else
            {
                customer.Insert();
            }
        }

        public static void Delete(int id)
        {
            new Customer().Delete(id);
        }

        #endregion
    }
}