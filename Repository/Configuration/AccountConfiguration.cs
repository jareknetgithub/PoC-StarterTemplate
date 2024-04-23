using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasData(
                new Account
                {
                    Id = new Guid("FFF1AE44-C101-4B6C-B417-BF3DF4BA7E89"),
                    Email = "admin@admin.com",
                    Name = "Admin",
                    Password = "$2a$11$NgSnpDYhRUi/aDft.7.T7uBGCl/B1dOp1CNAyYjy0zfbic75cs8SW",
                    Phone = "1234567890"
                },
                new Account
                {
                    Id= new Guid("5D533B96-5FAE-4147-B16B-C78EDA4C3078"),
                    Email = "user@user.com",
                    Name = "User",
                    Password = "$2a$11$eCDWs7kKK3W/245SitYLz..wghxOWSU3By6sS60CMYGb3PfPWOXZe",
                    Phone = "1234567891"
                });
        }
    }
}
