using Microsoft.Extensions.DependencyInjection;
using Amazon.Suporte.Services;
namespace Amazon.Suporte.Setup.Services
{
    public static class DependencyInjection
	{
		public static void RegisterServices(this IServiceCollection services)
        {
			services.AddScoped<IProblemService, ProblemService>();
		}
	}
}
