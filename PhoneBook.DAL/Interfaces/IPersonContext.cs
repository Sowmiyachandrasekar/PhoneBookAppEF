using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DAL.Interfaces
{
    public interface IPersonContext : IDbContext,IDisposable
    {
        DbSet<Person> Persons { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<State> States { get; set; }
        DbSet<City> Cities { get; set; }
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbEntityEntry Entry(object entity);

    }
}
