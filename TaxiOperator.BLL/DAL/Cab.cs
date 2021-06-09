using System;
using System.Collections.Generic;

#nullable disable

namespace TaxiOperator.BLL.DAL
{
    public partial class Cab
    {
        public Cab()
        {
            CabDrivers = new HashSet<CabDriver>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CabDriver> CabDrivers { get; set; }
    }
}
