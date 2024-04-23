namespace Account.Get.Me
{
    internal sealed class Request
    {
        [FromClaim]
        public Guid AccountID { get; set; }

    }

    internal sealed class Validator : Validator<Request>
    {
        public Validator()
        {

        }
    }

    internal sealed class Response:ModelDTO
    {
        
    }
}
