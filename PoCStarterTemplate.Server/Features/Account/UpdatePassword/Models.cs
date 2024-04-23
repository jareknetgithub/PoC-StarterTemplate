namespace Account.UpdatePassword
{
    internal sealed class Request
    {
        [FromClaim]
        public Guid AccountID { get; set; }
        public string Password {  get; set; }
    }

    internal sealed class Validator : Validator<Request>
    {
        public Validator()
        {

        }
    }

}
