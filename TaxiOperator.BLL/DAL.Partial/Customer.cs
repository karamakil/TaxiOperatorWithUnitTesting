using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TaxiOperator.BLL.Interface;

namespace TaxiOperator.BLL.DAL
{
    public partial class Customer : IDbObject<Customer>
    {
        #region Public Methods

        public List<Customer> GetList()
        {
            using (var ctx = new TaxiOperatorContext())
            {
                return ctx.Customers.Include(x => x.Addresses).ToList();
            }
        }

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
            using (var ctx = new TaxiOperatorContext())
            {
                ctx.Customers.Add(this);
                ctx.SaveChanges();
            }
        }

        public Customer Find(int id)
        {
            using (var ctx = new TaxiOperatorContext())
            {
                return ctx.Customers.FirstOrDefault(x => x.Id == id);
            }
        }

        public void Delete()
        {
            using (var ctx = new TaxiOperatorContext())
            {
                ctx.Customers.Attach(this);
                ctx.Customers.Remove(this);
                ctx.SaveChanges();
            }
        }

        #endregion

    }
}
