using Microsoft.EntityFrameworkCore;
using ProductsRegister.Data.Context;
using ProductsRegister.API.Configurations;
using Microsoft.AspNetCore.Identity;
using ProductsRegister.Business.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.



builder
    .AddApiConfig()
    .AddCorsConfig()
    .AddSwaggerConfig()
    .AddDbContextConfig()
    .AddIdentityConfig();







builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.ResolveDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //Registra o middleware para porder utiliz�-lo
    app.UseSwaggerUI();
    //Registra o middleware de UI
    app.UseCors("Development");
}
else
{
    app.UseCors("Production");
}

app.UseHttpsRedirection();

app.UseAuthentication();//Primeiro

app.UseAuthorization();//Segundo

//Esta ordem � importante, sen�o o Identity n�o funciona!!!


app.MapControllers();
//Mapeia todas as controllers que tiverem a assinatura de ApiController
//Cria um dicion�rio (cole��o) de rotas;
//

app.Run();
