
namespace Account.Get
{
    public class Request
    {
        public string Id {  get; set; }

    }

    public class UserModelExt : ModelDTO
    {
        public Guid Id { get; set; }
    }

    public class Response
    {
        public IEnumerable<UserModelExt> Accounts { get; set; }
    }
}
