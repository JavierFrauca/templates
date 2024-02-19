using [PROYECT_NAME].Entity.V1;
using Microsoft.EntityFrameworkCore;

namespace [PROYECT_NAME].Data.V1;

public partial class [PROYECT_NAME]Context : DbContext
{
    public LtcpublicacionContext()
    {
    }

    public [PROYECT_NAME]Context(DbContextOptions<[PROYECT_NAME]Context> options)
        : base(options)
    {
    }

    public virtual DbSet<EntityName> DbTableName { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<ClienteEntity>()
        //    .HasMany(c => c.Empresas)
        //    .WithOne(p => p.Cliente)
        //    .OnDelete(DeleteBehavior.Cascade);
    }

}
