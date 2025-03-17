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
			#endregion

			#region Mapping Configurations
			var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
			typeAdapterConfig.Scan(Assembly.GetExecutingAssembly());
			#endregion
			//services.AddAutoMapper(typeof(MappingProfiles).Assembly);
			//services.AddScoped<IWardrobeRepository, WardrobeRepository>();
			//services.AddScoped<IPieceRepository, PieceRepository>();
			//services.AddScoped<IOutfitRepository, OutfitRepository>();
			services.AddControllers();
			return services;
		}
	}
}
