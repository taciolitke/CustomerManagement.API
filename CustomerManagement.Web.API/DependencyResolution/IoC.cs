using CustomerManagement.Web.Repository.DataBase.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CustomerManagement.Web.Domain.Interfaces.Services;
using CustomerManagement.Web.Domain.Services;
using CustomerManagement.Web.Domain.Interfaces.Repositories;
using CustomerManagement.Web.Repository.DataBase.Repositories;

namespace CustomerManagement.Web.API.DependencyResolution
{
    public static class IoC
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.DatabaseDependencies();
            services.ServiceDependencies();
            services.RepositoryDependencies();
        }

        private static void DatabaseDependencies(this IServiceCollection services)
        {
            services.AddDbContext<ManagementCustomerDbContext>(options =>
             options.UseInMemoryDatabase("InMemoryDatabase"));
        }
        private static void ServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAutenticationService, AutenticationService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IUserService, UserService>();
        } 
        private static void RepositoryDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
