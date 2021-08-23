using BancoDigital.Controllers;
using BancoDigital.Models;
using BancoDigital.Models.DTO;
using BancoDigital.Repositorys;
using BancoDigital.Services;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestBancoDigital.Controllers
{
   public class ControllersTestes
    {
        
        private readonly IOperacoesContaService _operacoesContaService;
        private readonly ContasController _contasController;

        public ControllersTestes()
        {
            _operacoesContaService = Substitute.For<IOperacoesContaService>();
            _contasController = new ContasController(_operacoesContaService);
        }

        [Fact]
        public async Task Controler__Metodo_Saldo__Se_Saldo_Existe_Retorna__ok()
        {
            string entrada="23";

            Conta conta = new() { ContaNumero = "23", Saldo = 30.00 };

            _operacoesContaService.ContaExistente(entrada).Returns(true);

            _operacoesContaService.Saldo(entrada).Returns(conta.Saldo);


            var okResult = await _contasController.Saldo(entrada);

            Assert.IsType<OkObjectResult>(okResult);

        }

        [Fact]
        public async Task Controler__Metodo_Saldo_Se_Saldo_De_Conta_Nao_Existe_Retorna__Error()
        {
            string entrada = "24";

            

            _operacoesContaService.ContaExistente(entrada).Returns(false);

            


            var badRequest = await _contasController.Saldo(entrada);

            Assert.IsType<BadRequestResult>(badRequest);

        }


        [Fact]
        public async Task Controler__Metodo_Sacar_Se_Saldo_De_Conta_For_Maior_Que__Saque_Return_OK()
        {

            EntradaContaDTO entrada = new () {Conta="23",Saldo=30 };
            Conta contaBd = new() { ContaNumero = "23", Saldo = 80 };
            Conta contaAtualizada = new() { ContaNumero = "23", Saldo = 50 };
          
            _operacoesContaService.Saldo(entrada.Conta).Returns(contaBd.Saldo);

            _operacoesContaService.Sacar(entrada).Returns(contaAtualizada);

            var okResult = await _contasController.Sacar(entrada);


            Assert.IsType<OkObjectResult>(okResult.Result);

        }



        [Fact]
        public async Task Controler__Metodo_Sacar_Se_Saldo_De_Conta_For_Menor_Que__Saque_Return_Error()
        {

            EntradaContaDTO entrada = new() { Conta = "23", Saldo = 90 };
            Conta contaBd = new() { ContaNumero = "23", Saldo = 80 };
            
            
            _operacoesContaService.Saldo(entrada.Conta).Returns(contaBd.Saldo);


           

            var UnprocessableEntity = await _contasController.Sacar(entrada);


            Assert.IsType<UnprocessableEntityObjectResult>(UnprocessableEntity.Result);

        }

        [Fact]
        public async Task Controler__Metodo_Depositar_Se_Conta__Existir_Return_OK()
        {

            EntradaContaDTO entrada = new() { Conta = "23", Saldo = 30 };
          
            Conta contaAtualizada = new() { ContaNumero = "23", Saldo = 50 };

            _operacoesContaService.Depositar(entrada).Returns(contaAtualizada);

          

            var okResult = await _contasController.Depositar(entrada);


            Assert.IsType<OkObjectResult>(okResult.Result);

        }

        [Fact]
        public async Task Controler__Metodo_Depositar_Se_Conta__Null_Return_Error()
        {

            EntradaContaDTO entrada = new() { Conta = "23", Saldo = 30 };

            Conta contaAtualizada =null;

            _operacoesContaService.Depositar(entrada).Returns(contaAtualizada);



            var NotFoundResult = await _contasController.Depositar(entrada);


            Assert.IsType<NotFoundResult>(NotFoundResult.Result);

        }

    }
}
