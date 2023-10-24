using Microsoft.EntityFrameworkCore;
using ProductsRegister.Data.Context;

namespace ProductsRegister.API.Configurations
{
    public static class DbContextConfig
    {
        public static WebApplicationBuilder AddDbContextConfig(this WebApplicationBuilder builder)
        {

            builder.Services.AddDbContext<MyDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            return builder;

        }

    }
}
