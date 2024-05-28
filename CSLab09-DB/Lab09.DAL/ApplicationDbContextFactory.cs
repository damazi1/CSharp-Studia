using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab09.DAL
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args = null)
        {
            if (args == null || args.Length == 0)
                throw new ArgumentNullException("Arguments are empty.");
            var di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            var dataDir = $@"{di.Parent?.Parent?.Parent?.FullName}\Database";
            var connectionString = args.FirstOrDefault();
            connectionString = connectionString?.Replace($"|DataDirectory|", dataDir);
            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            options.UseSqlServer(connectionString!);
            return new ApplicationDbContext(options.Options);
        }
    }
}
