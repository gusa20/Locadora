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
        public virtual Estudio Estudio { get; set; }
        public int DiretorId { get; set; }
        public virtual Diretor Diretor { get; set; }
        public CultureInfo Idioma { get; set; }
        public virtual ICollection<Midia> Midias { get; set; }
    }
}
    