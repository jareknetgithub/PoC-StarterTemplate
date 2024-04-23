using PoCStarterTemplate.Auth;

namespace Account.Login
{
    internal sealed class Request
    {
        public string LoginEmail { get; set; } = "user@user.com";
        public string Password { get; set; } = "user";

    }

    internal sealed class Validator : Validator<Request>
    {
        public Validator()
        {

        }
    }

    internal sealed class Response
    {
        public string FullName { get; set; }
        public JwtToken Token { get; set; } = new();
        public IEnumerable<string> PermissionSet { get; set; }
    }
}
