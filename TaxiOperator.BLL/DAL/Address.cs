using System;
using System.Collections.Generic;

#nullable disable

namespace TaxiOperator.BLL.DAL
{
    public partial class Address
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
