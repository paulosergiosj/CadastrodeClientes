using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CadastroDeClientes.Models;

namespace CadastroDeClientes.Data
{
    public class CadastroDeClientesContext : DbContext
    {
        public CadastroDeClientesContext (DbContextOptions<CadastroDeClientesContext> options)
            : base(options)
        {
        }

        public DbSet<CadastroDeClientes.Models.Cliente> Cliente { get; set; }
    }
}
