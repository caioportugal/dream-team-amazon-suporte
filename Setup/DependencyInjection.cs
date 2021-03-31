using Microsoft.Extensions.DependencyInjection;
using Amazon.Suporte.Services;
using Amazon.Suporte.Database;
using Microsoft.EntityFrameworkCore;

namespace Amazon.Suporte.Setup.Services
{
    public static class DependencyInjection
	{
		public static void RegisterServices(this IServiceCollection services)
        {
			services.AddScoped<IProblemService, ProblemService>();
			services.AddScoped<IProducerService, ProducerService>();
			services.AddScoped<DbContext, SupportDBContext>();
			services.AddScoped<SupportDBContext>();			
		}

		public static void RegisterHostedService(this IServiceCollection services)
        {
			services.AddHostedService<ConsumerService>();
		}
	}
}