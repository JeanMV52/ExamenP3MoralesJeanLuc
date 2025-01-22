using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExamenP3JM.Models;

namespace ExamenP3JM.Services
{
    public class BaseDatosSQLite
    {
        private readonly SQLiteAsyncConnection _database;

        public BaseDatosSQLite(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<PeliculaBaseDatos>().Wait();
        }

        public Task<int> SavePeliculaAsync(PeliculaBaseDatos pelicula)
        {
            return _database.InsertAsync(pelicula);
        }

        public Task<List<PeliculaBaseDatos>> GetPeliculasAsync()
        {
            return _database.Table<PeliculaBaseDatos>().ToListAsync();
        }
    }
}

