

namespace Account.Get
{
    internal sealed class Mapper : Mapper<EmptyRequest, Response, Entities.Models.Account>
    {
        internal Response FromEntityList(IEnumerable<Entities.Models.Account> lstAcc)
        {
            Response response = new Response();
            List<UserModelExt> lstModels = new List<UserModelExt>();
            foreach (var item in lstAcc) 
            {
                lstModels.Add(new UserModelExt()
                {
                    Id = item.Id,
                    Email = item.Email!,
                    Name = item.Name!,
                    Phone = item.Phone!
                });
            }

            response.Accounts = lstModels.AsEnumerable();

            return response;
        }
    }
}
