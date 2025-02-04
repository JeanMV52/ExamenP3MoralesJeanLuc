﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ExamenP3JM.Interfaces;
using ExamenP3JM.Models;
using System.Windows.Input;

namespace ExamenP3JM.ViewModels
{
    public class BusquedaViewModel : BaseViewModel
    {
        private readonly IPeliculaInterface _peliculaService;

        private string _textoBusqueda;
        public string TextoBusqueda
        {
            get => _textoBusqueda;
            set => SetProperty(ref _textoBusqueda, value);
        }

        private string _resultado;
        public string Resultado
        {
            get => _resultado;
            set => SetProperty(ref _resultado, value);
        }

        private Pelicula _peliculaEncontrada;
        public Pelicula PeliculaEncontrada
        {
            get => _peliculaEncontrada;
            set => SetProperty(ref _peliculaEncontrada, value);
        }

        public ICommand BuscarPelicula { get; }
        public ICommand LimpiarBusqueda { get; }

        public BusquedaViewModel(IPeliculaInterface peliculaService)
        {
            _peliculaService = peliculaService;
            BuscarPelicula = new Command(async () => await Buscar());
            LimpiarBusqueda = new Command(Limpiar);
        }

        public async Task Buscar()
        {
            if (string.IsNullOrWhiteSpace(TextoBusqueda))
            {
                Resultado = "Por favor, ingresa un nombre de película.";
                return;
            }

            try
            {
                var peliculas = await _peliculaService.Obtener();
                var pelicula = peliculas.FirstOrDefault(p =>
                    p.title.Contains(TextoBusqueda, StringComparison.OrdinalIgnoreCase));

                if (pelicula != null)
                {
                    PeliculaEncontrada = pelicula;
                    Resultado = $"Película encontrada: {pelicula.title}";
                }
                else
                {
                    Resultado = "No se encontraron películas con ese nombre.";
                }
            }
            catch (Exception ex)
            {
                Resultado = $"Error al buscar película: {ex.Message}";
            }
        }

        public void Limpiar()
        {
            TextoBusqueda = string.Empty;
            Resultado = string.Empty;
            PeliculaEncontrada = null;
        }
    }
}

