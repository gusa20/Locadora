using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public DateTime DataDevolucao { get; set; }
        //Cliente
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public Midia Midia { get; set; }
        public StatusEmprestimo _statusEmprestimo { get; set; }
        public enum StatusEmprestimo
        {
            Atrasado, EmVigor, Devolvido
        }
    }
}
