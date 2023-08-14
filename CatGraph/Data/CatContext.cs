using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CatGraph.Data;

public class CatContext : DbContext
{
    public CatContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Cat> Cats => Set<Cat>();
}
