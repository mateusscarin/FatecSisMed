using Microsoft.AspNetCore.Identity;

namespace FatecSisMed.IdentityServer.Data.Entities;

public class ApplicationUser : IdentityUser
{
    public string FirtName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
}
