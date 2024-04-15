﻿using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using _253504_Noskovich.Application;
using _253504_Noskovich.Persistense;
using _253504_Noskovich.Persistense.Data;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace _253504_Noskovich.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            string settingsStream = "_253504_Noskovich.UI.appsettings.json";

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream(settingsStream);
            builder.Configuration.AddJsonStream(stream);

            var connStr = builder.Configuration.GetConnectionString("SqliteConnection");
            string dataDirectory = FileSystem.Current.AppDataDirectory + "/";
            connStr = String.Format(connStr, dataDirectory);
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(connStr)
                .Options;

            builder.Services
                .AddApplication()
                .AddPersistence(options)
                .RegisterPages()
                .RegisterViewModels();

            DbInitializer.Initialize(builder.Services.BuildServiceProvider()).Wait();



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
