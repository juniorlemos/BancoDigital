using BancoDigital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoDigital.Repositorys
{
   public interface IContaRepository 
    {
        bool ContaExistente (string conta);
        
        Task <Conta>PegarConta(string objeto);
        Task <Conta> Atualizar(Conta conta);
        
    }
}
