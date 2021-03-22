using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Amazon.Suporte.Database
{
    public static class PrepDB
    {
        public static void ExecuteMigrations(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<SupportDBContext>();
                context.Database.Migrate();
            }
        }
    }
}
