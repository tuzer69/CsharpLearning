using System;
using System.Windows;
using UseCases.Interfeces;
using HomeWork.Entities;
using HomeWork.ViewModel;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UseCases;
using UseCases.Commands;

namespace HomeWork
{
    using ClientsReposytory;
    using Database;
    public partial class App
    {
        private static IHost _host;

        public static IHost Host => _host ??=
            Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host;
            base.OnStartup(e);

            await host.StartAsync().ConfigureAwait(false);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            var host = Host;
            await host.StopAsync().ConfigureAwait(false);
            host.Dispose();
            _host = null;
        }

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<MainViewModel>();
            services.AddMediatR(typeof(AddSimpleAccountCommand));
            services.AddTransient<IReposytory<Client>, MSSQLReposytory>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<Database>();
        }
    }
}
