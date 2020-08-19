using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DAL.Interfaces
{
    public interface IDbContext
    {
        int SaveChanges();
    }
}
