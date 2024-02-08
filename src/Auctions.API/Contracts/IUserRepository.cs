using Auctions.API.Entities;

namespace Auctions.API.Contracts
{
    public interface IUserRepository
    {
        bool ExistsUserWithEmail(string email);
        User GetUserByEmail(string email);
    }
}
