using System.Data.Entity.ModelConfiguration;
using DataAccess.Entities;

namespace DataAccess.Maps
{
    public class PersonMap : EntityTypeConfiguration<PersonEntity>
    {
        public PersonMap()
        {
            ToTable("Person")
                .HasKey(x => x.PersonId);

            Property(x => x.FirstName).HasMaxLength(50);
            Property(x => x.LastName).HasMaxLength(50);
        }
    }
}
