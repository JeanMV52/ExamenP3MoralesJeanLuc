using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ExamenP3JM.Models
{
    public class PeliculaBaseDatos
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string ActorPrincipal { get; set; }
        public string Awards { get; set; }
        public string Website { get; set; }
        public string JMorales { get; set; }
    }
}
