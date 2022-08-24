using Autofac;
using Autofac.Extensions.DependencyInjection;
using DaghanDigital.Core.Repositories;
using DaghanDigital.Core.Services;
using DaghanDigital.Core.UnitOfWorks;
using DaghanDigital.Repository;
using DaghanDigital.Repository.Repositories;
using DaghanDigital.Repository.UnitOfWorks;
using DaghanDigital.Service.Mapping;
using DaghanDigital.Service.Services;
using DaghanDigital.Service.Validations;
using DaghanDigital.WebAPI.Filters;
using DaghanDigital.WebAPI.Middlewares;
using DaghanDigital.WebAPI.Modules;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>  options.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//Api'nin fluent validation sonras�nda filter sonu�lar�n� d�nd�rmesini bask�l�yoruz bu �ekilde hata mesajlar�n� kendi istedi�imiz �ekilde d�nd�rebiliyoruz.
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(NotFoundFilter<>));

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});
/*AutoFac*/
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCustomException();
app.UseAuthorization();

app.MapControllers();

app.Run();
