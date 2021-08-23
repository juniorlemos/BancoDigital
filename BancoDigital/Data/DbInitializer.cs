using BancoDigital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoDigital.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ContaContext context)
        {
            context.Database.EnsureCreated();

            if (context.Contas.Any())
            {
                return;   
            }

            var contas = new Conta[]
            {
            new Conta{ContaNumero="23",Saldo=30},
           new Conta{ContaNumero="2244",Saldo=30},
           new Conta{ContaNumero="1122",Saldo=500},
           new Conta{ContaNumero="2233",Saldo=30.00},
           new Conta{ContaNumero="3344",Saldo=56.00},
           new Conta{ContaNumero="1155",Saldo=43.45},
           new Conta{ContaNumero="253",Saldo=45}
          
            };
            foreach (Conta c in contas)
            {
                context.Contas.Add(c);
            }
            context.SaveChangesAsync();

        }
    }
}

