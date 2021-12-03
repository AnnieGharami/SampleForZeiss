using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Platform.ApplicationServices.AuthService
{
    /// <summary>
    /// <para>Annie - 26-FEB-2020</para>
    /// <para>On successful authentication the IsAuthenticated method generates a JWT (JSON Web Token) </para>
    /// <para>using the JwtSecurityTokenHandler class that generates a token that is </para>
    /// <para>digitally signed using a secret key stored in appsettings.json.</para>
    /// <para>The JWT token is returned to the client application which then must include it in</para>
    /// <para>the HTTP Authorization header of subsequent web api requests for authentication.</para>
    /// </summary>
    public class AuthenticationService: IAuthenticationService
    {
        private readonly IUserManagementService _userManagementService;
        private readonly TokenManagement _tokenManagement;

        public AuthenticationService(IUserManagementService service, IOptions<TokenManagement> tokenManagement)
        {
            _userManagementService = service;
            _tokenManagement = tokenManagement.Value;
        }

        /// <summary>
        /// Returns the JWT on successful authentication
        /// </summary>
        /// <param name="user"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool IsAuthenticated(AuthenticateModel user, out string token)
        {
            token = string.Empty;
            var authenticateduser = _userManagementService.ValidUser(user.Username, user.Password);

            if (authenticateduser == null)
                return false;

            var claim = new[]
            {
                new Claim(ClaimTypes.Name, authenticateduser.UserName),
                 new Claim(ClaimTypes.Role, authenticateduser.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_tokenManagement.Secret));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwToken = new JwtSecurityToken(
                null, null, claim,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            token = new JwtSecurityTokenHandler().WriteToken(jwToken);
            return true;
        }
    }
}

