using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiRestCore.Modelo;

namespace ApiRestCore.Data
{
    public class ApiRestCoreContext : DbContext
    {
        public ApiRestCoreContext (DbContextOptions<ApiRestCoreContext> options)
            : base(options)
        {
        }

        public DbSet<ApiRestCore.Modelo.Producto> Producto { get; set; } = default!;
    }
}
