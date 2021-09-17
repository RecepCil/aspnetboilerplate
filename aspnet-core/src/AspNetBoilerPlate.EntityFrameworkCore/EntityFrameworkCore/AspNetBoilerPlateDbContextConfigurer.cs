using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AspNetBoilerPlate.EntityFrameworkCore
{
    public static class AspNetBoilerPlateDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AspNetBoilerPlateDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AspNetBoilerPlateDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
