using ExamenP3JM.Models;

namespace ExamenP3JM.Interfaces
{
    public interface IPeliculaInterface
    {
        public Task<List<Pelicula>> Obtener();
    }
}
