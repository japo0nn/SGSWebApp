using Microsoft.EntityFrameworkCore;
using SGSWebApp.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGSWebApp.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Container> Containers { get; }
        DbSet<Operation> Operations { get; }
    }
}
