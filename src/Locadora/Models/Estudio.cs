using System;
using System.Globalization;

namespace Locadora.Models
{
    public class Estudio
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public DateTime DataEstreia { get; set; }
        public DateTime DataUltimoFilme { get; set; }
        public RegionInfo Pais { get; set; }
        public string CountryDisplayName
        {
            get { return Pais == null ? null : Pais.DisplayName; }
            set { Pais = new RegionInfo(value); }
        }
    }
}