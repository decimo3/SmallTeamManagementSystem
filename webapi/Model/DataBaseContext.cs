using Microsoft.EntityFrameworkCore;
using mestreruan.api.Models;
namespace mestreruan.api.Database;
public class DataBaseContext : DbContext
{
  private string server = System.Environment.GetEnvironmentVariable("POSTGRES_HOST");
  private string dbuser = System.Environment.GetEnvironmentVariable("POSTGRES_USER");
  private string dbpass = System.Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
  private string dbbase = System.Environment.GetEnvironmentVariable("POSTGRES_DB");
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseNpgsql($"Host={server};Username={dbuser};Password={dbpass};Database={dbbase}");
  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Funcionario>().HasKey(i => i.re);
    modelBuilder.Entity<Funcionario>().ToTable("funcionario");
    modelBuilder.Entity<Viatura>().ToTable("viatura");
    modelBuilder.Entity<Equipe>().HasKey(o => new {o.servico, o.espelho, o.dia});
    modelBuilder.Entity<Equipe>().ToTable("equipe");
    modelBuilder.Entity<Telefone>().HasKey(i => i.numero);
    modelBuilder.Entity<Telefone>().ToTable("telefone");
  }
  public DbSet<Funcionario> Funcionarios { get; set; }
  public DbSet<Viatura> Viaturas { get; set; }
  public DbSet<Equipe> Equipes { get; set; }
  public DbSet<Telefone> Telefones { get; set; }
}
