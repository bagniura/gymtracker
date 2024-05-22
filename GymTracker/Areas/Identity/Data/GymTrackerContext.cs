using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GymTracker.Models;

namespace GymTracker.Data;

public class GymTrackerContext : IdentityDbContext<IdentityUser>
{
    public GymTrackerContext(DbContextOptions<GymTrackerContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }


    public DbSet<GymTracker.Models.Training>? Training { get; set; }

    public DbSet<GymTracker.Models.TrainingPlan>? TrainingPlan { get; set; }

    public DbSet<GymTracker.Models.Userr>? Userr { get; set; }
}
