using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using PhoneBookApp.Models;
using System.Linq;
using System.Web;
using PhoneBookApp.Interfaces;

namespace PhoneBookApp.DAL
{
    public class PersonContext : DbContext
    {
        public PersonContext() : base("PersonContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PersonContext, PhoneBookApp.Migrations.Configuration>("PersonContext"));
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Person>()
                    .Map(map =>
                    {
                        map.Properties(p => new
                        {
                            p.ID,
                            p.FirstName,
                            p.LastName,
                            p.PhoneNumber,
                            p.EmailAddress,
                            p.IsActive
                        });
                        map.ToTable("Person");
                    })
                    // Map to the Address table  
                    .Map(map =>
                    {
                        map.Properties(p => new
                        {
                            p.ID,
                            p.AddressOne,
                            p.AddressTwo,
                            p.CityId,
                            p.StateId,
                            p.CountryId,
                            p.Pincode,
                            //p.IsActive
                        });
                        map.ToTable("Address");
                    });
        }
        public override int SaveChanges()
        {
            var Changed = ChangeTracker.Entries();
            if (Changed != null)
            {
                foreach (var entry in Changed.Where(e => e.State == EntityState.Deleted))
                {
                    entry.State = EntityState.Unchanged;
                    ((ISoftDeletable)entry.Entity).IsActive = false;
                    //if (entry.Entity is ISoftDeletable)
                    //{
                    //    // Set IsDeleted....
                    //    //((ISoftDeletable)entry.Entity).IsActive = true;
                    //}
                }
            }
            return base.SaveChanges();
        }
    }

}