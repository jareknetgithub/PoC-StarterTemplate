using Contracts;
using Microsoft.Extensions.Options;
using PoCStarterTemplate;
using PoCStarterTemplate.Auth;

using ToolsService;

namespace Account.Login
{
    internal sealed class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public IOptions<Settings> Settings { get; set; } = null!;
        public IRepositoryManager RepositoryManager { get; set; } = default!;
        public override void Configure()
        {
            Post("/account/login");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            Data.Repo = RepositoryManager;
            var acc = await Data.GetAccountAsync(r.LoginEmail);
            if (acc == null)
            {
                ThrowError("user not found", StatusCodes.Status404NotFound);
            }

            if (!r.Password.DB_value().Pwd_Verify(acc!.Password.DB_value()))
            {
                ThrowError("Password not valid!", StatusCodes.Status400BadRequest);
            }

            string sv = DateTime.Now.ToString();
            string sv1 = sv.DB_value();

            var expirDate = DateTime.Now.AddDays(1);
            var permissions = new Allow();

            Response.FullName = $"{acc.Name} - {acc.Email}";
            Response.Token.Expiry = expirDate.ToString();
            Response.PermissionSet = new List<string>() { Allow.Account_Read};// permissions.AllNames();

            Response.Token.Value = JWTBearer.CreateToken(signingKey: Settings.Value.Auth.SigningKey,
                expireAt: expirDate,
                privileges: p => 
                {
                    p.Permissions.AddRange(Response.PermissionSet);
                    p[Claim.AccountID]=acc.Id.ToString();
                });

        }
    }
}