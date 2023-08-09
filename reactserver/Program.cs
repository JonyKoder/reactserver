using Microsoft.EntityFrameworkCore;
using reactserver.database;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                        builder =>
                        {
                            builder.WithOrigins("http://localhost:3000") // ��������� ������ ������ ��� http://localhost:3000
                                   .AllowAnyMethod()
                                   .AllowAnyHeader();
                        });
        });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

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


