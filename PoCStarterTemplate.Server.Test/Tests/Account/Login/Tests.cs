using Contracts;
using System.Reflection.Metadata.Ecma335;
using Account.Login;
using System.Diagnostics;


namespace Tests.Account.Login
{
    public class Fixture(IMessageSink s) : TestFixture<Program>(s)
    {
        public IRepositoryManager Repo { get; set; } = default!;
        public string Password { get; set; } = default!;
        public Entities.Models.Account AccountUser { get; set; } = default!;

        protected override async Task SetupAsync()
        {
            Repo = Server.Services.GetService<IRepositoryManager>()!;

            Password = Fake.Internet.Password();
            AccountUser = Fake.AccountUser(null, Password);

            Repo.Account.CreateAccount(AccountUser);

            await Repo.SaveASync();
        }
        

        protected override async Task TearDownAsync()
        {
            Repo.Account.DeleteAccount(AccountUser);

            await Repo.SaveASync();

        }

    }
    public class Tests(Fixture f, ITestOutputHelper o): TestClass<Fixture>(f, o)
    {
        [Fact]
        public async Task Invalid_Login_Credentials()
        {
            Request req = new Request()
            {
                LoginEmail = Fixture.AccountUser.Email!,
                Password = Fake.Internet.Password()
            };

            var (resp, errresp) = await Fixture.Client.POSTAsync<Endpoint, Request, ErrorResponse>(req);

            resp.IsSuccessStatusCode.Should().BeFalse();
            
            errresp!.Errors.Should().NotBeNullOrEmpty();
           
        }

        [Fact]
        public async Task Login_DefaultUserDB_password_OK()
        {
            Request req = new Request()
            {
                LoginEmail = "user@user.com",
                Password = "user"
            };

            var(resp, resm) = await Fixture.Client.POSTAsync<Endpoint, Request, Response>(req);

            resp.IsSuccessStatusCode.Should().BeTrue();
            resp.StatusCode.Should().Be(HttpStatusCode.OK);
            
        }

        [Fact]
        public async Task Login_NewUser_OK()
        {

            Request req = new Request()
            {
                LoginEmail = Fixture.AccountUser.Email!,
                Password = Fixture.Password
            };

            var (resmsg, res) = await Fixture.Client.POSTAsync<Endpoint, Request, Response>(req);

            resmsg.IsSuccessStatusCode.Should().BeTrue();

            res.FullName.Should().NotBeNullOrEmpty();
            res.PermissionSet.Should().NotBeNullOrEmpty();


        }

    }
}
