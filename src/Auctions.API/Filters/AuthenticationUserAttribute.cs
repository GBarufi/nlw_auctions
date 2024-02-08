using Auctions.API.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Auctions.API.Filters
{
    public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private IUserRepository _userRepository;

        public AuthenticationUserAttribute(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var token = GetRequestToken(context.HttpContext);
                var email = FromBase64String(token);

                var userExists = _userRepository.ExistsUserWithEmail(email);

                if (!userExists)
                    context.Result = new UnauthorizedObjectResult("E-mail is not valid");
            }
            catch (Exception ex)
            {
                context.Result = new UnauthorizedObjectResult(ex.Message);
            }
        }

        private string GetRequestToken(HttpContext context)
        {
            var auth = context.Request.Headers.Authorization.ToString();

            if (string.IsNullOrEmpty(auth))
                throw new Exception("Token is missing");

            return auth["Bearer ".Length..];
        }

        private string FromBase64String(string base64)
        {
            return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(base64));
        }
    }
}
