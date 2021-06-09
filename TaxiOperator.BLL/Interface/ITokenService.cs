using TaxiOperator.BLL.DAL;

namespace TaxiOperator.BLL.Interface
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
