﻿using Microsoft.Extensions.Logging;
using ExamenP3JM.Interfaces;
using ExamenP3JM.Services;

namespace ExamenP3JM
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<BaseDatosSQLite>(s =>
              new BaseDatosSQLite(Path.Combine(FileSystem.AppDataDirectory, "peliculas.db"))
          );
            builder.Services.AddSingleton<IPeliculaInterface, PeliculaInterface>();
            builder.Services.AddSingleton<AppShell>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
