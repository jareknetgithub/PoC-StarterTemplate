using PoCStarterTemplate.Auth;
using System.ComponentModel;

namespace Account.UpdateData
{
    internal sealed class Request
    {
        [FromClaim]
        public Guid AccountID { get; set; }
        public string Name { get; set; }
        public string Phone {  get; set; }

    }

    internal sealed class Validator : Validator<Request>
    {
        public Validator()
        {

        }
    }

    internal sealed class Response
    {
        public bool OK { get; set; }
    }
}
