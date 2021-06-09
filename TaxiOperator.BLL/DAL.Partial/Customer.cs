using System;
using System.Linq;
using TaxiOperator.BLL.Interface;

namespace TaxiOperator.BLL.DAL
{
    public partial class Customer : IDbObject<Customer>
    {
        #region Public Methods

        public Customer GetRandom()
        {
            using (var ctx = new TaxiOperatorContext())
            {
                int toSkip = new Random().Next(0, ctx.Customers.Count());
                return ctx.Customers.Skip(toSkip).Take(1).First();
            }
        }

        public void Update()
        {
            using (var ctx = new TaxiOperatorContext())
            {
                ctx.Entry(this).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        public void SetVipCustomer(int id)
        {
            using (var ctx = new TaxiOperatorContext())
            {
                var customer = ctx.Customers.FirstOrDefault(x => x.Id == id);
                customer.IsVip = true;
                customer.Update();
            }
        }

        public void Insert()
        {
            throw new NotImplementedException();
        }

        public void GetList()
        {
            throw new NotImplementedException();
        }

        public Customer Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }


        #endregion

    }
}
