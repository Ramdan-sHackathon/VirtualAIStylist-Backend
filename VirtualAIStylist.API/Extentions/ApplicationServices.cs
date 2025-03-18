using Mapster;
using MediatR.NotificationPublishers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VirtualAIStylist.Application.Features.Authentication.Commands.CreateAccount;
using VirtualAIStylist.Application.Services;
using VirtualAIStylist.Domain.Entities;
using VirtualAIStylist.Domain.Interfaces;
using VirtualAIStylist.Domain.Repositories;
using VirtualAIStylist.Infrastructure.Authentication;
using VirtualAIStylist.Persistence.Data;
using VirtualAIStylist.Persistence.Repositories;

namespace VirtualAIStylist.API.Extentions
{
	public static class ApplicationServices
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
		{
			services.AddDbContext<VirtualAIStylistDbContext>(opt =>
			{
				opt.UseSqlServer(config.GetConnectionString("DataBaseConnection"));
			});

			services.AddIdentity<Account, IdentityRole>()
				.AddEntityFrameworkStores<VirtualAIStylistDbContext>()
				.AddDefaultTokenProviders();

			services.AddHttpContextAccessor();

			#region Mediator Service
			services.AddMediatR(cgf =>
			{
				cgf.RegisterServicesFromAssemblies(typeof(CreateAccountCommand).Assembly);
				cgf.NotificationPublisher = new TaskWhenAllPublisher();

			});
			#endregion

			#region Services
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<IMediaService, MediaService>();
			services.AddScoped<IAuthService, AuthService>();
			#endregion

			#region Mapping Configurations
			var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
			typeAdapterConfig.Scan(Assembly.GetExecutingAssembly());
			#endregion

			services.AddControllers();
			return services;
		}

		public static void ConfigureCORS(this IServiceCollection Services)
		{
			Services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy", builder =>
				{
					builder.AllowAnyOrigin();
					builder.AllowAnyMethod();
					builder.AllowAnyHeader();

				});
			});
		}
	}
}
