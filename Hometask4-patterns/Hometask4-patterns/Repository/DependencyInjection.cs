using Hometask4_patterns.Repository.Abstractions;
using Hometask4_patterns.Repository.Implementations;
using Hometask4_patterns.UnitOfWork;

namespace Hometask4_patterns.Repository
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddRepositoryLayers(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<,>), typeof(EfRepository<,>));
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
         

            return services;    
            
        }
    }
}
