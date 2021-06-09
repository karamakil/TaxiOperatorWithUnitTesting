using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiOperator.BLL.Interface
{
    public interface IDbObject<T>
    {
        void Insert();
        void GetList();
        T Find(int id);
        void Update();
        void Delete(int id);
        void Delete();
    }
}
