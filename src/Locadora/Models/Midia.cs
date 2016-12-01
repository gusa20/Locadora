using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Locadora.Models
{
    public class Midia
    {
        public int Id { get; set; }
        public Filme Filme { get; set; }
        public decimal Preco { get; set; }
        public CultureInfo Idioma { get; set; }
        public CultureInfo Legenda { get; set; }
    }
}

