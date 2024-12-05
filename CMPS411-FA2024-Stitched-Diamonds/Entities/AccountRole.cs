using CMPS411_FA2024_Stitched_Diamonds.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMPS411_FA2024_Stitched_Diamonds.Entities;

public class AccountRole : IdentityUserRole<int>
{
    public Account Account { get; set; }
    public Role Role { get; set; }
}

public class UserRoleEntityConfiguration : IEntityTypeConfiguration<AccountRole>
{
    public void Configure(EntityTypeBuilder<AccountRole> builder)
    {
        builder.HasOne(x => x.Account)
            .WithOne(x => x.Role);

        builder.HasOne(x => x.Role)
            .WithMany(x => x.Accounts)
            .HasForeignKey(x => x.UserId);
    }
}