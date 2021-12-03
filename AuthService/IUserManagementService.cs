namespace Platform.ApplicationServices.AuthService
{/// <summary>
 /// <para>Annie - 26-FEB-2020</para>
 /// <para>validates user credentials (to be implemented using database authentication)</para>
 /// </summary>
    public interface IUserManagementService
    {
        UserInfo ValidUser(string username, string password);
    }
}
