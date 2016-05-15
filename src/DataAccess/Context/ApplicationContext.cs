using System.Data.Entity;
using DataAccess.Maps;

namespace DataAccess.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<ApplicationContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PersonMap());
        }
    }
}
