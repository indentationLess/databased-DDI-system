using Microsoft.EntityFrameworkCore;
using DDIAPI.Models;
using Microsoft.Extensions.Options;
namespace DDIAPI.Models;
public class DDIAPIContext : DbContext {
    public DDIAPIContext(DbContextOptions<DDIAPIContext>options)
    :base(options){}
    // public DbSet<User> users {get; set;} = null!;
    public DbSet<DrugCategory> drugCategories {get; set;} = null!;
    public DbSet<Drug> drugs {get; set;} = null!;
    public DbSet<Interaction> interactions {get; set;} = null!;
    public DbSet<Severity> severities {get; set;} = null!;
    public DbSet<ClinicalRecommendation> clinicalRecommendations {get; set;} = null!;
    public DbSet<SystemAlert> systemAlerts {get; set;} = null!;
    public DbSet<MedicationLogs> medicationLogs {get; set;} = null!;
    public DbSet<HealthCareProvider> healthCareProviders {get; set;} = null!;
    public DbSet<Patient> patients {get; set;} = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Drug>()
        .HasOne(d => d.drugCategory)
        .WithMany(dc => dc.drugs)
        .HasForeignKey(d => d.DrugCategoryId);


}

}
