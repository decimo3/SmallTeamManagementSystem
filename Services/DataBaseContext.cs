using Microsoft.EntityFrameworkCore;
using sge.Entities;
namespace sge.Services;
public class DataBaseContext : DbContext
{
  private readonly IWebHostEnvironment _env;

  public DataBaseContext(IWebHostEnvironment env)
  {
    _env = env;
  }
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if(_env.IsDevelopment())
    {
      optionsBuilder.UseSqlite("Data Source=database.db");
    }
    if(_env.IsProduction())
    {
      string? server = System.Environment.GetEnvironmentVariable("POSTGRES_HOST");
      string? dbuser = System.Environment.GetEnvironmentVariable("POSTGRES_USER");
      string? dbpass = System.Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
      string? dbbase = System.Environment.GetEnvironmentVariable("POSTGRES_DB");
      optionsBuilder.UseNpgsql($"Host={server};Username={dbuser};Password={dbpass};Database={dbbase}");
    }
  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Funcionario>().HasKey(i => i.re);
    modelBuilder.Entity<Funcionario>().ToTable("funcionario");
    modelBuilder.Entity<Viatura>().ToTable("viatura");
    modelBuilder.Entity<Viatura>().HasKey(i => i.placa);
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
