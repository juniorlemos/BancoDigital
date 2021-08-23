using BancoDigital.Models;
using BancoDigital.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestBancoDigital.Repository
{
    public class ContaRepositoryTestes
    {

        private readonly ContaRepository _contaRepository;
        public ContaRepositoryTestes()
        {
            var dbInMemory = new DBInMemory();
            var context = dbInMemory.GetContext();
            _contaRepository = new ContaRepository(context);

        }

        [Fact]
        public async Task Repository_Pegar_Conta__Por_Numero_Metodo_Retorna_A_Conta()
        {
            string numeroConta = "23";

            var sucesso = await _contaRepository.PegarConta(numeroConta);
     

            Assert.NotNull(sucesso);

        }

        [Fact]
        public async Task Repository_Pegar_Conta__Por_Numero_Metodo_Retorna_Null()
        {
            string numeroConta = null;

            var sucesso = await _contaRepository.PegarConta(numeroConta);


            Assert.Null(sucesso);

        }


        [Fact]
        public void Repository_ContaExiste_Inserindo_NumeroConta_Metodo_Retorna_TRUE()
        {

            string numeroConta = "23";

            var sucesso =  _contaRepository.ContaExistente(numeroConta);


            Assert.True(sucesso);
            
        }

       


        [Fact]
        public async Task Repository_Atualizar_Inserindo_Conta_Metodo_Retorna_Saldo_Atualizado()
        {

          var conta=  new Conta() { ContaNumero = "23", Saldo = 40.00 };



            var sucesso = await _contaRepository.Atualizar(conta);


            Assert.NotNull(sucesso);

        }


    }
}
