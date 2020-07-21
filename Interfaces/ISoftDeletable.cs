using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.Interfaces
{
    interface ISoftDeletable
    {
        bool IsActive { get; set; }
    }
}
