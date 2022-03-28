using Autofac;
using Home_Work_19;

namespace Presenter;

public class PLocator
{
    public IPresenter Presenter => App.Container.Resolve<IPresenter>();

}