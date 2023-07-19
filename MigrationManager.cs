﻿using System;

public static class MigrationManager
{
    public static IHost MigrateDatabase(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var databaseService = scope.ServiceProvider.GetRequiredService<Database>();
            try
            {
                databaseService.CreateDatabase("BooksManager");
            }
            catch
            {
                //log errors or ...
                throw;
            }
        }
        return host;
    }
}
