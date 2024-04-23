using Microsoft.AspNetCore.Mvc;
using PoCStarterTemplate.Auth;

namespace Account.SignUp
{
    internal sealed class Request
    {
        public string LoginEmail {  get; set; }
        public string Password { get; set; }
        public string Name {  get; set; }
        public string Phone { get; set; }

    }

    internal sealed class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(r => r.LoginEmail)
                .NotEmpty().WithMessage("Nie może być puste");

            RuleFor(r => r.Password)
                .NotEmpty().WithMessage("Haslo nie może być puste");
        }
    }

    internal sealed class Response
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
