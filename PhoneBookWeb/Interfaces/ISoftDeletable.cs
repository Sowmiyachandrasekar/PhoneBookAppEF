using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookWeb.Interfaces
{
    public interface ISoftDeletable
    {
        bool IsActive { get; set; }
    }
}
