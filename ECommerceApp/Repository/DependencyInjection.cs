using System;
using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories;
using Repository.Repositories.Interfaces;

namespace Repository
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddRepositoryLayer(this IServiceCollection services)
		{
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<ISettingRepository, SettingRepository>();
            return services;
		}
	}
}

