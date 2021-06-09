﻿using System;
using System.Collections.Generic;
using System.Text;
using TaxiOperator.BLL.Interface;
using System.Linq;

namespace TaxiOperator.BLL.DAL
{
    public partial class User : IDbObject<User>
    {
        #region Public Methods

        public User Find(string userName, string password)
        {
            using (var ctx = new TaxiOperatorContext())
            {
                return ctx.Users.FirstOrDefault(x => x.UserName == userName && x.Password == password);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void GetList()
        {
            throw new NotImplementedException();
        }

        public void Insert()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public User Find(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
