using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace CMPS411_FA2024_Stitched_Diamonds.Entities;

public class Role : IdentityRole<int>
{
    public List<AccountRole> Accounts { get; set; } = new();
}