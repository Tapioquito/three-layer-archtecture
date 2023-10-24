using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductsRegister.Business.Models;

namespace ProductsRegister.Data.Context
{
    public class MyDbContext : IdentityDbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            //Algumas configurações:
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            //Não rastrear as entidades, para não ficar carregando na memória
            ChangeTracker.AutoDetectChangesEnabled = false;
            //Não detectar mudanças, para não ficar carregando na memória
        }
        //Mapear Entidades de negócios:
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suplliers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100");
            }



            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);
            //toda vez que o projeto for inicializado ele vai pegar todos os tipos 
            //que estão no assembly do DbContext e vai aplicar as configurações





            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
                //Impede que haja deleção em cascata em objetos relacionais
            }

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(entry => entry.Entity.GetType().GetProperty("RegisterDate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("RegisterDate").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("RegisterDate").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
