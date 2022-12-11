using Castle.Core.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using TestProject.WebAPI.Models;

namespace TestProject.WebAPI.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options, ILogger<Context> logger): base(options)
        {
            Logger = logger;
            if (!this.Database.CanConnect())
            {
                Logger.LogError("can't connect to database.....!!!!");
            }
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        private ILogger<Context> Logger { get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().HasAlternateKey(x => x.EmailId);
        }
    }
}
