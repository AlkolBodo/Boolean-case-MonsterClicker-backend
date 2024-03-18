using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MonsterClickerAPI.Enumfolder;
using System.Diagnostics;

namespace MonsterClickerAPI.Data
{
    public class DataContext: IdentityUserContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
                   
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
