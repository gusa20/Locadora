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
        public int FilmeId { get; set; }
        public virtual Filme Filme { get; set; }
        public decimal Preco { get; set; }
        public CultureInfo Idioma { get; set; }
        public string TwoLetterISOLanguageName
        {
            get { return Idioma == null ? null : Idioma.TwoLetterISOLanguageName; }
            set { Idioma = new CultureInfo(value); }
        }
        public CultureInfo Legenda { get; set; }
        public string TwoLetterISOSubtitleName
        {
            get { return Legenda == null ? null : Legenda.TwoLetterISOLanguageName; }
            set { Legenda = new CultureInfo(value); }
        }
    }
}

