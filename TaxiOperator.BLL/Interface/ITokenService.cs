using System;
using System.Collections.Generic;
using System.Text;
using TaxiOperator.BLL.DAL;

namespace TaxiOperator.BLL.Interface
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
