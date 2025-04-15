using Microsoft.EntityFrameworkCore;


namespace RentifyAPI.Models;

public class RentifyContext : DbContext
{
    public RentifyContext(DbContextOptions<RentifyContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}
