using BancoDigital.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoDigital.Data
{
    public class ContaContext:DbContext
    {
        public ContaContext(DbContextOptions<ContaContext> options) : base(options)
        {

        }

        public DbSet<Conta> Contas { get; set; }


    }
}
