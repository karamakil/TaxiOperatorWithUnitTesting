using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TaxiOperator.BLL.DAL
{
    public partial class Customer
    {
        public Customer()
        {
            Addresses = new HashSet<Address>();
        }
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? VipRation { get; set; }
        public bool? IsVip { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
