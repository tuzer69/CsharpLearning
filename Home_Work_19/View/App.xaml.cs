using System.Windows;
using Autofac;

namespace Home_Work_19
{

    public partial class App
    {
        private MainWindow _window;

        private static IContainer _container;

        public static IContainer Container => _container ??= Program.ConteinerCreator.Config();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using var scope = Container.BeginLifetimeScope();

            _window = scope.Resolve<MainWindow>();
            
            _window.Show();
        }
    }

 
}
