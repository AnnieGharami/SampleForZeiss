using Platform.ApplicationServices.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Platform.ApplicationServices.AuthService
{
    /// <summary>
    /// <para>Annie - 26-FEB-2020</para>
    /// <para>To contain the database operations of validating Username and Password with User DB.</para>
    /// <para>For demo : hardcoded list has been used.</para>
    /// </summary>
    public class UserManagementService : IUserManagementService
    {
        /// <summary>
        /// <para>Method for authenticating user credentials</para>
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserInfo ValidUser(string username, string password)
        {
            List<UserInfo> _users = new List<UserInfo>
        {
            new UserInfo {  UserName = "admin", UserPassword = "admin", Role = UserRoles.Admin },
            new UserInfo {  UserName = "user", UserPassword = "user", Role = UserRoles.General }
        };
            var user = _users.SingleOrDefault(x => x.UserName == username && x.UserPassword == password);

            // return null if user not found
            if (user == null)
                return null;
            return user;
        }

    }
}
