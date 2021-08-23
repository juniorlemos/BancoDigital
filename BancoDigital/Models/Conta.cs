using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BancoDigital.Models
{
    public class Conta
    {
        [Required]
        [Key]
        public string ContaNumero { get; set; }

        [Required]
        public double Saldo { get; set; }
    }
}
