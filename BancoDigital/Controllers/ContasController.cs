using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BancoDigital.Data;
using BancoDigital.Models;
using BancoDigital.Services;
using BancoDigital.Models.DTO;

namespace BancoDigital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
       
        private readonly IOperacoesContaService _service;

        public ContasController( IOperacoesContaService service)
        {
            
            _service = service;
        }



        [HttpGet("Saldo/{NumeroConta}")]
        public async Task<ActionResult> Saldo(string conta)
        {

            var existeConta = _service.ContaExistente(conta);

            if (existeConta)
            {
                var saldo = await _service.Saldo(conta);


                return Ok("saldo: " + saldo );
            }
            return BadRequest();
        }


        [HttpPut("Depositar")]
        public async Task<ActionResult<Conta>> Depositar([FromBody] EntradaContaDTO conta)
        {

            var contaAtualizada = await _service.Depositar(conta);
            if (contaAtualizada != null)
            {
                return Ok(contaAtualizada);
            }

            return NotFound();
        }


        [HttpPut("Sacar")]
        public async Task<ActionResult<Conta>> Sacar([FromBody] EntradaContaDTO conta)
        {

            var saldo = await _service.Saldo(conta.Conta);
          
            if (saldo >= conta.Saldo)
            {

                var contaAtualizada = await _service.Sacar(conta);
                return Ok(contaAtualizada);
            }
            return UnprocessableEntity("Saldo Insuficiente");

            
        }




      



       



       
    }
}
