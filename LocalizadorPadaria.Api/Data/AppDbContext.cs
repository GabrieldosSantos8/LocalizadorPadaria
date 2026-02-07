using Microsoft.EntityFrameworkCore;
using LocalizadorPadaria.Api.Models;

namespace LocalizadorPadaria.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Padaria> Padarias { get; set; }
}