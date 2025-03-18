using Clivia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Clivia.Infrastructure.Data
{
    public class CliviaDBContextFactory : IDesignTimeDbContextFactory<CliviaDBContext>
    {
        public CliviaDBContext CreateDbContext(string[] args)
        {
            // 1. Obtener la ruta del directorio de contenido (donde está appsettings.json)
            var basePath = Directory.GetCurrentDirectory();
            // Console.WriteLine($"Base path: {basePath}"); // Imprime la ruta para depuración

            // 2. Construir la configuración desde appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            // 3. Obtener la cadena de conexión
            var connectionString = configuration.GetConnectionString("CliviaDBConnection");
            // Console.WriteLine($"Connection string: {connectionString}"); // Imprime la cadena de conexión para depuración

            // 4. Crear las opciones del DbContext
            var builder = new DbContextOptionsBuilder<CliviaDBContext>();
            builder.UseNpgsql(connectionString);

            // 5. Crear y retornar el DbContext
            return new CliviaDBContext(builder.Options);
        }
    }
}