using Microsoft.EntityFrameworkCore;
using Lr12Task1.Models;

namespace Lr12Task1.Data;

public class UserContext : DbContext
{
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{ optionsBuilder.UseSqlServer("Server=DESKTOP-1JJ426J\\SQLEXPRESS;Database=lr12;Trusted_Connection=True;TrustServerCertificate=True;"); }
	public DbSet<User> Users { get; set; }
}

