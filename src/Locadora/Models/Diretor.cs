using System;

namespace Locadora.Models
{
    public class Diretor
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public int NumPremios { get; set; }
        public DateTime DataPrimeiroFilme { get; set; }
        public DateTime DataUltimoFilme { get; set; }
    }
}