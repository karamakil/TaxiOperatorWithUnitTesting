using System.Collections.Generic;
using TaxiOperator.BLL.DAL;

namespace TaxiOperator.BLL.Manager
{
    public class CabDriverManager
    {
        #region Static Methods
        public static List<V_CabDriver> List()
        {
            return new V_CabDriver().GetList();
        }

        #endregion
    }
}
