using FatecSisMed.IdentityServer.Configuration;
using FatecSisMed.IdentityServer.Data.Entities;
using FatecSisMed.IdentityServer.SeedDataBase.Interfaces;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FatecSisMed.IdentityServer.SeedDataBase.Entities;

public class DataBaseIdentityServerInitializer : IDataBaseInitializer
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public DataBaseIdentityServerInitializer(UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public void InitializeSeedRoles()
    {
        if (!_roleManager.RoleExistsAsync(IdentityConfiguration.Admin).Result)
        {
            IdentityRole roleAdmin = new IdentityRole();
            roleAdmin.Name = IdentityConfiguration.Admin;
            roleAdmin.NormalizedName = IdentityConfiguration.Admin.ToUpper();
            _roleManager.CreateAsync(roleAdmin).Wait();
        }
        if (!_roleManager.RoleExistsAsync(IdentityConfiguration.Client).Result)
        {
            IdentityRole roleClient = new IdentityRole();
            roleClient.Name = IdentityConfiguration.Client;
            roleClient.NormalizedName = IdentityConfiguration.Client.ToUpper();
            _roleManager.CreateAsync(roleClient).Wait();
        }
    }

    public void InitializeSeedUsers()
    {
        if (_userManager.FindByEmailAsync("mateus.scarin@fatec.sp.gov.br").Result is null)
        {
            ApplicationUser admin = new ApplicationUser()
            {
                UserName = "scarin",
                NormalizedUserName = "SCARIN",
                Email = "mateus.scarin@fatec.sp.gov.br",
                NormalizedEmail = "MATEUS.SCARIN@FATEC.SP.GOV.BR",
                EmailConfirmed = true,
                LockoutEnabled = false,
                PasswordHash = "+55 (17) 99778-6147",
                FirtName = "ADMIN",
                LastName = "Scarin",
                SecurityStamp = Guid.NewGuid().ToString()
            };
            IdentityResult resultAdmin = _userManager.CreateAsync(admin, "123Mudar*").Result;
            if (resultAdmin.Succeeded)
            {
                _userManager.AddToRoleAsync(admin, IdentityConfiguration.Admin).Wait();
                var adminClains = _userManager.AddClaimsAsync(admin, new Claim[]
                {
                    new Claim(JwtClaimTypes.Name, $"{admin.FirtName} {admin.LastName}"),
                    new Claim(JwtClaimTypes.GivenName, admin.FirtName),
                    new Claim(JwtClaimTypes.FamilyName, admin.LastName),
                    new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin)
                }).Result;
            }
        }
        if (_userManager.FindByEmailAsync("client@gmail.com").Result is null)
        {
            ApplicationUser client = new ApplicationUser()
            {
                UserName = "scarinclient",
                NormalizedUserName = "SCARINCLIENT",
                Email = "client@gmail.com",
                NormalizedEmail = "CLIENT@GMAIL.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                PhoneNumber = "+55 (11) 99012-3456",
                FirtName = "Usuario",
                LastName = "Client",
                SecurityStamp = Guid.NewGuid().ToString()

            };
            IdentityResult resultClient = _userManager.CreateAsync(client, "Client@1234").Result;
            if (resultClient.Succeeded)
            {
                _userManager.AddToRoleAsync(client, IdentityConfiguration.Client).Wait();
                var clientClaims = _userManager.AddClaimsAsync(client, new Claim[]
                {
                    new Claim(JwtClaimTypes.Name, $"{client.FirtName} {client.LastName}"),
                    new Claim(JwtClaimTypes.GivenName, client.FirtName),
                    new Claim(JwtClaimTypes.FamilyName, client.LastName),
                    new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client)
                }).Result;
            }
        }
    }

}
