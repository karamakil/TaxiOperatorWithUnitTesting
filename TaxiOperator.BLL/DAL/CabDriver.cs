using System;

#nullable disable

namespace TaxiOperator.BLL.DAL
{
    public partial class CabDriver
    {
        public int Id { get; set; }
        public int? DriverId { get; set; }
        public int? CabId { get; set; }
        public DateTime? TimeShift { get; set; }

        public virtual Cab Cab { get; set; }
        public virtual Driver Diver { get; set; }
    }
}
