using System.Collections.Generic;

namespace TaxiOperator.BLL.Interface
{
    public interface IDbObject<T>
    {
        void Insert();
        List<T> GetList();
        T Find(int id);
        void Update();
        void Delete(int id);
    }
}
