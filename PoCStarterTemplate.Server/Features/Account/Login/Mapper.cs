
namespace Account.Login
{
    internal sealed class Mapper:Mapper<Request, Response, Entities.Models.Account>
    {
        public override Response FromEntity(Entities.Models.Account acc)
            => new Response()
            {
                FullName = $"{acc.Name}"
            };
    }
}
