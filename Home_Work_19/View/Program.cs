using System;
using Autofac;
using Autofac.Core;
using Models;
using Models.Interfaces;
using Presenter;

namespace Home_Work_19
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

        public static class ConteinerCreator
        {
            public static IContainer Config()
            {
                var builder = new ContainerBuilder();

                builder.RegisterType<MainWindow>().AsSelf().SingleInstance();

                builder.RegisterType<MainWindow>().As<IView>().SingleInstance();

                builder.RegisterType<Presenter.Presenter>().As<IPresenter>().SingleInstance();

                builder.RegisterType<Presenter.Presenter>().AsSelf().SingleInstance();

                builder.RegisterType<AnimalModel>().As<IModel>();

                return builder.Build();
            }

        }

    }
}

