using Lr12Task2.Models;
using Microsoft.EntityFrameworkCore;

namespace Lr12Task2.Data;

public class CompanyContext : DbContext
{
    public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
    {
    }

    public DbSet<Company> Companies => Set<Company>();
}

