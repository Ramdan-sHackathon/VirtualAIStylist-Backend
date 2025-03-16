using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VirtualAIStylist.Domain.Entities;
using VirtualAIStylist.Persistence.Data;

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

			//services.AddAutoMapper(typeof(MappingProfiles).Assembly);
			//services.AddScoped<IUnitOfWork, UnitOfWork>();
			//services.AddScoped<IWardrobeRepository, WardrobeRepository>();
			//services.AddScoped<IPieceRepository, PieceRepository>();
			//services.AddScoped<IOutfitRepository, OutfitRepository>();
			services.AddControllers();
			return services;
		}
	}
}
