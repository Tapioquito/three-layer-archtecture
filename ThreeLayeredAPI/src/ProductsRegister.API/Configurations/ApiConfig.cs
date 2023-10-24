using System.Runtime.CompilerServices;

namespace ProductsRegister.API.Configurations
{
    public static class ApiConfig
    {
        public static WebApplicationBuilder AddApiConfig(this WebApplicationBuilder builder)
        {

            builder.Services.AddControllers().ConfigureApiBehaviorOptions(
                options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                });

            return builder;
        }
    }
}
