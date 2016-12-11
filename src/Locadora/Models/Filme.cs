using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Filme
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public DateTime DataEstreia { get; set; }
        public int NumPremios { get; set; }
        public Genero _genero { get; set; }
        public enum Genero
        {
            ACAO, COMEDIA, ROMANCE, DRAMA, DOCUMENTARIO
        }
        public int EstudioId { get; set; }
        [JsonIgnore]
        public virtual Estudio Estudio { get; set; }
        public int DiretorId { get; set; }
        [JsonIgnore]
        public virtual Diretor Diretor { get; set; }
        [JsonIgnore]
        public CultureInfo Idioma { get; set; }
        [JsonIgnore]
        public string TwoLetterISOLanguageName
        {
            get { return Idioma == null ? null : Idioma.TwoLetterISOLanguageName; }
            set { Idioma = new CultureInfo(value); }
        }
        [JsonIgnore]
        public virtual ICollection<Midia> Midias { get; set; }
    }
}
    