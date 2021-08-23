using BancoDigital.Data;
using BancoDigital.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBancoDigital
{
  public  class DBInMemory
    {
        private ContaContext _context;

        public DBInMemory()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<ContaContext>()
                .UseSqlite(connection)
                .EnableSensitiveDataLogging()
                .Options;
                
            _context =new ContaContext(options);

            InsertFakeData();
                

        }
        public ContaContext GetContext()=> _context;
        
        private void InsertFakeData()
        {
            if(_context.Database.EnsureCreated())
            {
                _context.Contas.Add(
                new Conta() { ContaNumero = "23", Saldo = 30.00 }
                    ) ;
                _context.Contas.Add(
              new Conta() { ContaNumero = "125", Saldo = 80.00 }
                  );
                _context.Contas.Add(
              new Conta() { ContaNumero = "33", Saldo = 50.00 }
                  );
                _context.Contas.Add(
              new Conta() { ContaNumero = "55", Saldo = 30.00 }
                  );


                _context.SaveChangesAsync();
            }

        }
    
    }
}
