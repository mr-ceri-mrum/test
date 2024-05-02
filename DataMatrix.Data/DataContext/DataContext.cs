using DataMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataMatrix.Data.DataContext;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    
    public DbSet<Order> Orders { get; set; }
}