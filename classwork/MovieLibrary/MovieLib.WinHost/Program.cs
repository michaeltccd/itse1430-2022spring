using System;
using System.Windows.Forms;

using Microsoft.Extensions.Configuration;

namespace MovieLib.WinHost
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Boilerplate - ignore
            var builder = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json");
            _configuration = builder.Build();
            
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        public static string GetConnectionString ( string name ) => _configuration.GetConnectionString(name);

        private static IConfiguration _configuration;
    }
}
