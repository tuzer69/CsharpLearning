using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Components
{
    public partial class ActionPanel
    {
        public ActionPanel() => InitializeComponent();

        #region Amount Transfer Property

        private static readonly FrameworkPropertyMetadata AmountMetadata = new()
        {
            DefaultValue = default(long),
            CoerceValueCallback = new CoerceValueCallback(CoerceAmount)

        };

        private static object CoerceAmount(DependencyObject d, object basevalue)
        {
            return basevalue;
        }

        public static readonly DependencyProperty AmountTransferProperty =
            DependencyProperty.Register(
                "AmountTransfer",
                typeof(long),
                typeof(ActionPanel),
                AmountMetadata,
                new ValidateValueCallback(x => true));

        public long AmountTransfer
        {
            get => (long)GetValue(AmountTransferProperty);
            set => SetValue(AmountTransferProperty, value);
        }

        #endregion

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
                typeof(ActionPanel),
                PanelMetadata,
                new ValidateValueCallback(x => true));


        private static object CoerceValue(DependencyObject d, object baseValue)
        {
            ActionPanel panel = (ActionPanel) d;
            Grid transPanel = panel.FindName("TransferMoney") as Grid;
            Grid addPanel = panel.FindName("AddAccount") as Grid;

            if ((PanelType) baseValue == PanelType.None)
            {
                panel.Visibility = Visibility.Collapsed;

            }
            else if ((PanelType) baseValue == PanelType.AddAccount)
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
            get => (PanelType) GetValue(PanelTypeProperty);
            set => SetValue(PanelTypeProperty, value);
        }

        #endregion

    }
}
