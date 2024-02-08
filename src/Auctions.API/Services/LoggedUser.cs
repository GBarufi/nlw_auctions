using Auctions.API.Contracts;
using Auctions.API.Entities;

namespace Auctions.API.Services
{
    public class LoggedUser : ILoggedUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;

        public LoggedUser(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }

        public User User()
        {
            var token = GetRequestToken();
            var email = FromBase64String(token);

            return _userRepository.GetUserByEmail(email);
        }

        private string GetRequestToken()
        {
            var auth = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

            return auth["Bearer ".Length..];
        }

        private string FromBase64String(string base64)
        {
            return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(base64));
        }
    }
}
