using Auctions.API.Contracts;
using Auctions.API.Entities;

namespace Auctions.API.Repositories.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly AuctionsDbContext _dbContext;

        public UserRepository(AuctionsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool ExistsUserWithEmail(string email) => _dbContext.Users.Any(user => user.Email.Equals(email));

        public User GetUserByEmail(string email) => _dbContext.Users.First(user => user.Email.Equals(email));
    }
}
