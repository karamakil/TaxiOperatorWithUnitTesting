using System.Collections.Generic;
using System.Linq;
using TaxiOperator.BLL.Interface;

namespace TaxiOperator.BLL.DAL
{
    public partial class V_CabDriver : IDbObject<V_CabDriver>
    {
        #region Public Methods

        public List<V_CabDriver> GetList()
        {
            using (var ctx = new TaxiOperatorContext())
            {
                return ctx.V_CabDrivers.ToList();
            }
        }
        
        void IDbObject<V_CabDriver>.GetList()
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete()
        {
            throw new System.NotImplementedException();
        }

        public void Insert()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public V_CabDriver Find(int id)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
