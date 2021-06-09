using System;

namespace TaxiOperator.BLL.DAL
{
    public partial class V_CabDriver
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public int CabId { get; set; }
        public string CabName { get; set; }
        public DateTime TimeShift { get; set; }
    }
}
