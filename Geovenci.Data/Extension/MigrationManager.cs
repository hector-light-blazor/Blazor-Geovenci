using System;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Geovenci.Data.Extension
{
    public static class MigrationManager
    {
        public static IHost ApplyMigration<T>(this IHost app) where T : DbContext
        {
            try
            {
                using var scope = app.Services.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<T>();
                db.Database.Migrate();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }

            return app;
        }
    }
}
