using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace LibHub.EntityFrameworkCore
{
    public static class LibHubDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<LibHubDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<LibHubDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
