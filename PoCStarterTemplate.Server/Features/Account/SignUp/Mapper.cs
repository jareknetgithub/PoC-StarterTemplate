using ToolsService;

namespace Account.SignUp
{
    internal sealed class Mapper : Mapper<Request, Response, Entities.Models.Account>
    {
        public override Entities.Models.Account ToEntity(Request r) => new Entities.Models.Account()
        {
            Id = Guid.NewGuid(),
            Name = r.Name,
            Password = r.Password.Pwd_MakeHash(),
            Phone = r.Phone,
            Email = r.LoginEmail
        };

        public override Response FromEntity(Entities.Models.Account acc) => new Response()
        {
            Id = acc.Id,
            DateCreated = DateTime.Now  
        };

    }
}