using BancoDigital.Models;
using BancoDigital.Models.DTO;
using BancoDigital.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoDigital.Services
{
    public class OperacoesContaService : IOperacoesContaService
    {
        public readonly IContaRepository _repository;
        public OperacoesContaService(IContaRepository repository)
        {
            _repository = repository;
        
        }

        public bool ContaExistente(string conta)
        {
          return  _repository.ContaExistente(conta);
        }

        public async Task<Conta> Depositar(EntradaContaDTO conta)
        {
          
         var contaBd = await _repository.PegarConta(conta.Conta);
            if (contaBd !=null)
                { 
                  contaBd.Saldo += conta.Saldo;

                  return await _repository.Atualizar(contaBd);
            }
            return null;
        }

        

        public async Task<Conta> Sacar(EntradaContaDTO conta)
        {
            var contaBd = await _repository.PegarConta(conta.Conta);
           
            contaBd.Saldo -= conta.Saldo;

            return await _repository.Atualizar(contaBd);
        }


        public async Task<double> Saldo(string contaNumero)
        {
            
             var resultado = await _repository.PegarConta(contaNumero);
          
            return resultado.Saldo;
        }


        

    }
}
