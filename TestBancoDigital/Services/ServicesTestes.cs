using BancoDigital.Models;
using BancoDigital.Models.DTO;
using BancoDigital.Repositorys;
using BancoDigital.Services;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace TestBancoDigital.Servicos
{
    public class ServicesTestes
    {
        private readonly IContaRepository _contaRepository;
        private readonly OperacoesContaService _operacoesContaService;
        public ServicesTestes()
        {
            _contaRepository = Substitute.For<IContaRepository>();
            _operacoesContaService = new OperacoesContaService(_contaRepository);
        }


        [Fact]
        public void Servico_Conta_Existente__Metodo_Retorna_True() { 
        
            string entrada="23";

            _contaRepository.ContaExistente(entrada).Returns(true);

            var sucesso =  _operacoesContaService.ContaExistente(entrada);

            Assert.True(sucesso);
        
        }


        [Fact]
        public async Task Servico_metodo_Saldo_Deve_Retornar_Double_SaldoDaConta()
        {

            string entrada = "23";
          Conta conta = new () { ContaNumero = "23", Saldo = 30.00 };

            
            _contaRepository.PegarConta(entrada).Returns(conta);

            var sucesso = await _operacoesContaService.Saldo(entrada);
            

            
            Assert.Equal(conta.Saldo,sucesso) ;
        }


        [Fact]
        public async Task Servico_metodo_Depositar_Deve_Retornar_Novo_Valor_Depositado_Somado()
        {


            EntradaContaDTO contaEntrada = new () { Conta = "23", Saldo = 30.00 };
            Conta contaBanco = new () { ContaNumero = "23", Saldo = 50.00 };
            Conta contaSoma = new () { ContaNumero = "23", Saldo = 80.00 };

            _contaRepository.PegarConta(contaEntrada.Conta).Returns(contaBanco);


            _contaRepository.Atualizar(contaBanco).Returns(contaSoma);


            var sucesso = await _operacoesContaService.Depositar(contaEntrada);



            Assert.Equal( contaSoma.Saldo, sucesso.Saldo);
        }

        [Fact]
        public async Task Servico_metodo_Depositar_Deve_Retornar_Null_Conta_Inexistente()
        {


            EntradaContaDTO contaEntrada = new EntradaContaDTO { Conta = "23", Saldo = 30.00 };
            
            Conta contaBanco = null;

            _contaRepository.PegarConta(contaEntrada.Conta).Returns(contaBanco);



            var sucesso = await _operacoesContaService.Depositar(contaEntrada);



            Assert.Null(sucesso);
        }



        [Fact]
        public async Task Servico_metodo_Sacar_Deve_Retornar_Novo_Valor_Sacado_Subtraido()
        {


            EntradaContaDTO contaEntrada = new() { Conta = "23", Saldo = 30.00 };
            Conta contaBanco = new() { ContaNumero = "23", Saldo = 50.00 };
            Conta contaSubtraida = new() { ContaNumero = "23", Saldo = 20.00 };

            _contaRepository.PegarConta(contaEntrada.Conta).Returns(contaBanco);


            _contaRepository.Atualizar(contaBanco).Returns(contaSubtraida);


            var sucesso = await _operacoesContaService.Sacar(contaEntrada);



            Assert.Equal(contaSubtraida.Saldo, sucesso.Saldo);
        }

    }

  
}
