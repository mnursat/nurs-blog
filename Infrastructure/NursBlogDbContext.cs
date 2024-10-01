using Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public sealed class NursBlogDbContext : DbContext
{
    public NursBlogDbContext(DbContextOptions<NursBlogDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<Post> Posts { get; set; }
}
