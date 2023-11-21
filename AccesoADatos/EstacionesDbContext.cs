using Microsoft.EntityFrameworkCore;
using Modelos;

namespace AccesoADatos;

public class EstacionesDbContext : DbContext
{
    
    public DbSet<EstacionDeServicio> EstacionDeServicio { get; set; } = null!;
    public DbSet<Combustible> Combustible { get; set; } = null!;
    
    public EstacionesDbContext(DbContextOptions<EstacionesDbContext> options)
        : base(options)
    {
    }

}