using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public String CPF { get; set; }
        public String Nome { get; set; }
        public DateTime DataAdesao { get; set; }
        public StatusCliente _statusCliente { get;set; }
        public virtual ICollection<Emprestimo> Emprestimos { get; set; }
        public enum StatusCliente
        {
            OK, ComAtraso
        }
    }
}
