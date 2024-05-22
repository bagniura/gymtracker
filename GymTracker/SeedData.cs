using Microsoft.AspNetCore.Identity;

public class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        Console.WriteLine("Initialize method called.");
        string roleName = "Administrator";
        IdentityResult roleResult;

        // Sprawd�, czy rola ju� istnieje
        var roleExist = await roleManager.RoleExistsAsync(roleName);
        if (!roleExist)
        {
            // Je�li rola nie istnieje, utw�rz j�
            roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
        }

        // Sprawd�, czy administrator ju� istnieje
        IdentityUser admin = await userManager.FindByEmailAsync("admin@admin.com");

        if (admin == null)
        {
            // Utw�rz administratora tylko je�li nie istnieje
            IdentityUser user = new IdentityUser()
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
            };

            // Je�li administrator nie istnieje, utw�rz go
            IdentityResult result = await userManager.CreateAsync(user, "Admin123$");

            if (result.Succeeded)
            {
                user.EmailConfirmed = true;
                await userManager.UpdateAsync(user);

                // Przypisz rol� "Administrator" do administratora
                await userManager.AddToRoleAsync(user, roleName);
            }
        }
    }
}