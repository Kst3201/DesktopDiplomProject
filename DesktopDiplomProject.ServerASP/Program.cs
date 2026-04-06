
using DesktopDiplomProject.Server.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DesktopDiplomProject.ServerASP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
#if DEBUG
            //builder.Services.AddSwaggerGen();
#endif
            builder.Services.AddDbContext<UpgradePCApplicationContext>(options =>
                {
#if RELEASE
                    options.UseNpgsql(builder.Configuration.GetConnectionString("ReleaseConnectionString"));
#else
                    options.UseNpgsql(builder.Configuration.GetConnectionString("DebugConnectionString"));
#endif
                });


        var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
#if DEBUG
                app.UseSwagger();
                app.UseSwaggerUI();
#endif
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
