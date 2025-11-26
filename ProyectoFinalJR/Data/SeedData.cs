using Microsoft.AspNetCore.Identity;

namespace ProyectoFinalJR.Data;

public class SeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        
        string[] Roles = { "Admin", "Usuario" };

        foreach (var role in Roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }

        
        string adminEmail = "admin@system.com";
        string adminPassword = "Admin123.";

        var adminUser = await userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            adminUser = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(adminUser, adminPassword);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
            else
            {
                throw new Exception("No se pudo crear el usuario administrador inicial.");
            }
        }


        // ==== ASIGNAR ADMIN A UREÑA DE SER NECESARIO ====
        var urena = await userManager.FindByIdAsync("328bb2bf-1219-4b32-923f-34acd82b75df");

        if (urena != null)
        {
            if (!await userManager.IsInRoleAsync(urena, "Admin"))
            {
                await userManager.AddToRoleAsync(urena, "Admin");
            }
        }
    }
}
