using System.Windows.Controls;
using System.Windows.Documents;
using Models.Base;
using Models.Interfaces;
using Presenter;

namespace Home_Work_19
{
    public partial class MainWindow : IView
    {
        private readonly IPresenter _presenter;

        public MainWindow(IPresenter presenter)
        {
            InitializeComponent();

            _presenter = presenter;

        }

        private void Grid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _presenter.CurentAnimal = (sender as Grid).DataContext as IAnimal;
        }
    }

}
