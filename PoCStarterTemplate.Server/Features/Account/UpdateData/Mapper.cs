

namespace Account.UpdateData
{
    internal sealed class Mapper : Mapper<Request, EmptyResponse, Entities.Models.Account>
    {
        public override Entities.Models.Account ToEntity(Request r) => new Entities.Models.Account()
        {
            Id = r.AccountID,
            Name = r.Name,
            Phone = r.Phone
        };

        public override Entities.Models.Account UpdateEntity(Request r, Entities.Models.Account acc)
        {
            acc.Phone = r.Phone;
            acc.Name = r.Name;

            return acc;
        }

        

    }
}