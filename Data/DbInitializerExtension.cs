﻿namespace FortRoboticsSA.Data
{
    internal static class DbInitializerExtension
    {
        public static IApplicationBuilder SeedSqlServer(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<DataContext>();
                DbInitializer.Initialize(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return app;
        }
    }
}
