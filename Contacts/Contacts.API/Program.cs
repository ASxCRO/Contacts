
using Contacts.API.Data;
using Contacts.API.Data.Repositories.Implementation;

namespace Contacts.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<DbConnectionFactory>();
        builder.Services.AddScoped<IContactRepository, ContactRepository>();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowVueApp",
                builder => builder
                            .AllowAnyOrigin() 
                            .AllowAnyHeader()
                            .AllowAnyMethod());
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors("AllowVueApp");

        app.UseAuthorization();

        app.MapControllers();


        app.Run();
    }
}
