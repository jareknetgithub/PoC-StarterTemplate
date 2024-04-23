
namespace Account.Get.Me
{
    internal sealed class Mapper : Mapper<Request, Response, Entities.Models.Account>
    {
        public override Response FromEntity(Entities.Models.Account? acc)
            => new Response()
            {
                Email = acc.Email!,
                Name = acc.Name!,
                Phone = acc.Phone!
            };
    }
}