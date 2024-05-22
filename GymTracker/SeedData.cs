using Microsoft.AspNetCore.Identity;

public class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        Console.WriteLine("Initialize method called.");
        string roleName = "Administrator";
        IdentityResult roleResult;

        // SprawdŸ, czy rola ju¿ istnieje
        var roleExist = await roleManager.RoleExistsAsync(roleName);
        if (!roleExist)
        {
            // Jeœli rola nie istnieje, utwórz j¹
            roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
        }

        // SprawdŸ, czy administrator ju¿ istnieje
        IdentityUser admin = await userManager.FindByEmailAsync("admin@admin.com");

        if (admin == null)
        {
            // Utwórz administratora tylko jeœli nie istnieje
            IdentityUser user = new IdentityUser()
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
            };

            // Jeœli administrator nie istnieje, utwórz go
            IdentityResult result = await userManager.CreateAsync(user, "Admin123$");

            if (result.Succeeded)
            {
                user.EmailConfirmed = true;
                await userManager.UpdateAsync(user);

                // Przypisz rolê "Administrator" do administratora
                await userManager.AddToRoleAsync(user, roleName);
            }
        }
    }
}