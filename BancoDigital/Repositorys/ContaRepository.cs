using BancoDigital.Data;
using BancoDigital.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoDigital.Repositorys
{
    public class ContaRepository :IContaRepository
    {
        private readonly ContaContext _context;
        public ContaRepository(ContaContext context)
        {
            _context = context;              }

        public  async Task<Conta>Atualizar(Conta conta )
        {

            var entry = _context.Contas.First(e => e.ContaNumero == conta.ContaNumero);
            _context.Entry(entry).CurrentValues.SetValues(conta);



            await _context.SaveChangesAsync();

            return  conta;
        }

      
        public bool ContaExistente(string conta)
        {
            
            return _context.Contas.Any(c => c.ContaNumero == conta);
        }

      

        public async Task<Conta> PegarConta(string conta)
        {
           return await _context.Contas.FindAsync(conta);
        }

        
    }
}
