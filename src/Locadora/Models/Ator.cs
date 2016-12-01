using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Ator
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public int NumPremios { get; set; }
        public DateTime DataPrimeiroFilme { get; set; }
        public DateTime DataUltimoFilme { get; set; }
    }
}
