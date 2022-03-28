using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace HomeWork
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            App app = new App();
            app.InitializeComponent();
            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args);
            hostBuilder.UseContentRoot(Environment.CurrentDirectory);
            hostBuilder.ConfigureAppConfiguration((host, cfg) =>
            {
                cfg.SetBasePath(Environment.CurrentDirectory);
                cfg.AddJsonFile("appsettings.json", true, true);
            });

            hostBuilder.ConfigureServices(App.ConfigureServices);

            return hostBuilder;
        }
    }
}