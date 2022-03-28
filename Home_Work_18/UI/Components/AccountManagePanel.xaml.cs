using System.Windows;
using System.Windows.Controls;
using Components;

namespace HomeWork.Components
{
    public partial class AccountManagePanel
    {
        public AccountManagePanel() => InitializeComponent();

        #region Panel Type Property

        private static readonly FrameworkPropertyMetadata PanelMetadata = new()
        {
            DefaultValue = PanelType.None,
            CoerceValueCallback = new CoerceValueCallback(CoerceValue)

        };

        public static readonly DependencyProperty PanelTypeProperty =
            DependencyProperty.Register(
                "PanelType",
                typeof(PanelType),
                typeof(AccountManagePanel),
                PanelMetadata,
                new ValidateValueCallback(x => true));


        private static object CoerceValue(DependencyObject d, object baseValue)
        {
            AccountManagePanel panel = (AccountManagePanel)d;
            Grid transPanel = panel.FindName("TransferMoney") as Grid;
            Grid addPanel = panel.FindName("AddAccount") as Grid;

            if ((PanelType)baseValue == PanelType.None)
            {
                panel.Visibility = Visibility.Collapsed;

            }
            else if ((PanelType)baseValue == PanelType.AddAccount)
            {
                transPanel.Visibility = Visibility.Hidden;
                addPanel.Visibility = Visibility.Visible;
                panel.Visibility = Visibility.Visible;

            }
            else
            {
                addPanel.Visibility = Visibility.Hidden;
                transPanel.Visibility = Visibility.Visible;
                panel.Visibility = Visibility.Visible;
            }

            return baseValue;
        }

        public PanelType PanelType
        {
            get => (PanelType)GetValue(PanelTypeProperty);
            set => SetValue(PanelTypeProperty, value);
        }

        #endregion


    }
}
