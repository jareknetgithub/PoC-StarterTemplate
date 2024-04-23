using Bogus;
using ToolsService;

using AccountLogin = Account.Login;

namespace Tests.Account
{
    internal static class Fakes
    {
        internal static Entities.Models.Account AccountUser(this Faker f, Guid? id, string? password=null)
        {
            return new Entities.Models.Account()
            {
                Id = id.HasValue? id.Value: Guid.NewGuid(),
                Email = f.Internet.Email(),
                Name = f.Name.FirstName(),
                Password = string.IsNullOrEmpty(password)? f.Internet.Password().Pwd_MakeHash(): password.Pwd_MakeHash(),
                Phone = f.Phone.PhoneNumber()
            };
        }

        internal static AccountLogin.Request LoginRequest(this Faker f)
        {
            return new AccountLogin.Request()
            {
                LoginEmail = f.Internet.Email(),
                Password = f.Internet.Password().Pwd_MakeHash()
            };
        }
    }
}
