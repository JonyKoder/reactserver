using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Npgsql;
using reactserver.Application.Interfaces;
using reactserver.Application.Repositoryes;
using reactserver.Application.Repositoryes.Interfaces;
using reactserver.Application.Services;
using reactserver.database;
using reactserver.Domain.Models;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        //builder.Services.AddSpaStaticFiles(configuration =>
        //{
        //    configuration.RootPath = "clientapp/build";
        //});
        //AddPeopleMigration(builder);
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
        builder.Services.AddTransient<IIndividualRepository, IndividualRepository>();
        builder.Services.AddTransient<IIndividualService, IndividualService>();
        builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
        builder.Services.AddTransient<ICompanyService, CompanyService>();
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                        builder =>
                        {
                            builder.WithOrigins("http://localhost:3000") // Разрешить доступ только для http://localhost:3000
                                   .AllowAnyMethod()
                                   .AllowAnyHeader();
                        });
        });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        //app.UseStaticFiles();
        //app.UseSpaStaticFiles();
        //app.UseSpa(spa =>
        //{
        //    spa.Options.SourcePath = "clientapp";
        //    if (app.Environment.IsDevelopment())
        //    {
        //        spa.UseReactDevelopmentServer(npmScript: "start");
        //    }
        //});
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseStaticFiles();
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.UseCors();

        app.Run();
    }

  
}



