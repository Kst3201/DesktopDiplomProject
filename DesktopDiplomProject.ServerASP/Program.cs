
using DesktopDiplomProject.Server.Data.Configuration;
using DesktopDiplomProject.Server.Models.Entities.Components.CPUs;
using DesktopDiplomProject.Server.Models.Entities.Components.Drives;
using DesktopDiplomProject.Server.Models.Entities.Components.Motherboards;
using DesktopDiplomProject.Server.Models.Entities.Components.VideoCards;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services.DefuzzifyFunctions;
using DesktopDiplomProject.ServerASP.Features.Authentification;
using DesktopDiplomProject.ServerASP.Features.Authentification.JWTTokens;
using DesktopDiplomProject.ServerASP.Features.Authentification.JWTTokens.RefreshTokenGenerators;
using DesktopDiplomProject.ServerASP.Features.Authentification.Password.Cryptographer;
using DesktopDiplomProject.ServerASP.Features.Authentification.Permissions;
using DesktopDiplomProject.ServerASP.Features.Authentification.Verifiers;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.CPU;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Drive;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.GPU;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Motherboard;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.NamedUnits;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.RAM;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.RAM.RAMType;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.VideoCard;
using DesktopDiplomProject.ServerASP.Features.PCCombine.Models.PersonalComputers;
using DesktopDiplomProject.ServerASP.Features.PCCombine.Services;
using DesktopDiplomProject.ServerASP.Features.PCCombine.Services.PCBuild;
using DiplomDataLibrary.PCComponents.DTO.Components;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens.Experimental;
using System.Text.Json;

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
            builder.Services.AddSwaggerGen();
#if DEBUG
#endif
            builder.Services.AddDbContext<UpgradePCApplicationContext>(options =>
                {
#if RELEASE
                    options.UseNpgsql(builder.Configuration.GetConnectionString("ReleaseConnectionString"));
#else
                    options.UseNpgsql(builder.Configuration.GetConnectionString("DebugConnectionString"));
#endif
                });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        ClockSkew = TimeSpan.FromSeconds(30),
                        IssuerSigningKey = new SymmetricSecurityKey(
                            System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"] ?? string.Empty))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            // ТУТ МЫ УВИДИМ РЕАЛЬНУЮ ПРИЧИНУ
                            Console.WriteLine("=== ОШИБКА АУТЕНТИФИКАЦИИ ===");
                            Console.WriteLine($"Сообщение: {context.Exception.Message}");
                            Console.WriteLine($"Тип: {context.Exception.GetType().Name}");

                            if (context.Exception is SecurityTokenExpiredException)
                                Console.WriteLine("ПРИЧИНА: Токен просрочен");
                            else if (context.Exception is SecurityTokenInvalidSignatureException)
                                Console.WriteLine("ПРИЧИНА: Неверная подпись (неправильный секретный ключ)");
                            else if (context.Exception is SecurityTokenInvalidIssuerException)
                                Console.WriteLine("ПРИЧИНА: Неверный Issuer");
                            else if (context.Exception is SecurityTokenInvalidAudienceException)
                                Console.WriteLine("ПРИЧИНА: Неверный Audience");
                            else if (context.Exception is SecurityTokenNoExpirationException)
                                Console.WriteLine("ПРИЧИНА: В токене нет срока действия");
                            else if (context.Exception is ArgumentException)
                                Console.WriteLine("ПРИЧИНА: Неверный формат токена (возможно отсутствует Bearer)");

                            return Task.CompletedTask;
                        },

                        OnTokenValidated = context =>
                        {
                            Console.WriteLine("=== УСПЕХ! Токен валиден ===");
                            return Task.CompletedTask;
                        },

                        OnChallenge = context =>
                        {
                            Console.WriteLine("=== ВЫЗВАН CHALLENGE (возврат 401) ===");
                            Console.WriteLine($"Error: {context.Error}");
                            Console.WriteLine($"ErrorDescription: {context.ErrorDescription}");

                            // ЭТО ВАЖНО: чтобы клиент получил детали
                            context.HandleResponse();
                            context.Response.StatusCode = 401;
                            context.Response.ContentType = "application/json";

                            var error = new { error = "Unauthorized", details = context.ErrorDescription ?? "Unknown" };
                            context.Response.WriteAsync(JsonSerializer.Serialize(error));

                            return Task.CompletedTask;
                        }
                    };
                });
            builder.Services.AddScoped<IFuzzyService<int>, FuzzyIntService>();
            builder.Services.AddScoped<IFuzzyService<double>, FuzzyDoubleService>();
            builder.Services.AddScoped<IDefuzzifyFunction, WeightAverageOfPeaksDeffuzifyFunction>();
            builder.Services.AddScoped<IComponentNamedUnitService<CPUSocketEntity>
                , NativeComponentNamedUnitService<CPUSocketEntity>>();
            builder.Services.AddScoped<IComponentNamedUnitService<MBSizeEntity>
                , NativeComponentNamedUnitService<MBSizeEntity>>();
            builder.Services.AddScoped<IComponentNamedUnitService<DriveConnectionInterfaceEntity>
                , NativeComponentNamedUnitService<DriveConnectionInterfaceEntity>>();
            builder.Services.AddScoped<IComponentNamedUnitService<PCIEInterfaceEntity>
                , NativeComponentNamedUnitService<PCIEInterfaceEntity>>();
            builder.Services.AddScoped<ICPUService, CPUService>();
            builder.Services.AddScoped<IDriveService, DriveService>();
            builder.Services.AddScoped<IGPUService, GPUService>();
            builder.Services.AddScoped<IMotherboardService, MotherboardService>();
            builder.Services.AddScoped<IComponentService<RAMTypeDTO>, RAMTypeService>(); 
            builder.Services.AddScoped<IRAMService, RAMService>();
            builder.Services.AddScoped<IVideoCardService, VideoCardService>();
            builder.Services.AddScoped<IPasswordService, NativePasswordService>();
            builder.Services.AddScoped<IPermissionService, PermissionService>();
            builder.Services.AddScoped<IUserVerifier, NativeUserVerifier>();
            builder.Services.AddScoped<IRefreshTokenGenerator, NativeRefershTokenGenerator>();
            builder.Services.AddScoped<IJWTTokenService, JWTTokenService>();
            builder.Services.AddScoped<IAuthentificationService, AuthentificationService>();
            builder.Services.AddScoped<IPCBuildService, PCBuildService>();
            builder.Services.AddScoped<IPCUpgradeService, PCUpgradeService>();
            builder.Services.AddScoped<PCPresetService>();

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

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
