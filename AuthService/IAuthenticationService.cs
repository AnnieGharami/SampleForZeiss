namespace Platform.ApplicationServices.AuthService
{/// <summary>
 /// <para>Annie - 26-FEB-2020</para>
 /// <para>authenticating user credentials and returning a JWT token</para>
 /// </summary>
    public interface IAuthenticationService
    {
        bool IsAuthenticated(AuthenticateModel user, out string token);
    }
}
