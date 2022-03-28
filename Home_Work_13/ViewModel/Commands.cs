using System.Globalization;
using System.Windows;
using HomeWork13.Entities;

namespace HomeWork13.ViewModel
{
    public partial class MainViewModel
    {
        #region Команда выход (Exit)

        private bool CanExitAppCommand(object parameter) => true;
        private void OnExitAppCommand(object parameter) => Application.Current.Shutdown();

        #endregion

        #region Команд подготовки к добавлению БА

        private bool CanAddAccount(object parametr) => SelectedClient != null;
        private void OnAddAccoun(object parameter)
        {
            IsEnableButtonsPanel = false;
            IsEnableClientList = false;
            VisibilityCreateAccPanel = Visibility.Visible;

        }

        #endregion

        #region Команда создание БА

        private bool CanCreateAccount(object parametr) => true;
        private void OnCreateAccount(object parameter)
        {
            IClient tmpClient = SelectedClient;

            if ((parameter as string) == "deposit")
            {
               tmpClient.AddDepositAccount();
            }
            else
            {
                tmpClient.AddSimpleAccount();

            }
            IsEnableButtonsPanel = true;
            IsEnableClientList = true;
            VisibilityCreateAccPanel = Visibility.Hidden;
        }

        #endregion
        
        #region Команда удаление банковского счета

        private bool CanRemoveAccount(object parametr) => SelectedAccount != null;
        private void OnRemoveAccount(object parameter)
        {
            IClient tmpClient = SelectedClient;
            tmpClient.RemoveAccount(SelectedAccount.model);
           
        }

        #endregion

        #region Команда подготовки к переводу на свой Аккаунт

        private bool CanInternalTransferPrep(object parametr) => SelectedAccount != null;
        private void OnInternalTransferPrep(object parametr)
        {
            IsEnableButtonsPanel = false;
            IsEnableClientList = false;
            TransferButtonText = "Перевести";
            TransferPanelText = "Выберите счет для перевода";
            VisibilityTransferPanel = Visibility.Visible;
            OutAccount = SelectedAccount;
            TransferPanelAmount = "";

        }

        #endregion

        #region Команда перевода или пополнения Аккаунта

        private bool CanBalanceTransfer(object parametr)
        {
            if ((parametr as string) == "AddBalance")
            {
                return true;
            }
            else if ((parametr as string) == "ExternalTransfer")
            {
                if (SelectedClient != OutClient &&
                    SelectedAccount != OutAccount &&
                    SelectedAccount != null) return true;
                else return false;
            }
            else
            {
                return SelectedAccount != OutAccount;
            }
        }
        private void OnBalanceTransfer(object parametr)
        {
            IAccount tmpAccount = OutAccount;
            while (!long.TryParse(TransferPanelAmount,
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out var outAmount))
            {
                TransferPanelText = "Введенное значение должно быть число больше 0"; return;
            }

            if ((parametr as string) == "AddBalance")
            {
                IAccount tmpAddBalance = SelectedAccount;
                tmpAddBalance = tmpAddBalance.AddBalance(long.Parse(TransferPanelAmount));
            }
            else if ((parametr as string) == "ExternalTransrer")
            {
                tmpAccount.ExternalTransfer(SelectedAccount, long.Parse(TransferPanelAmount));
            }
            else
            {
                tmpAccount.BalanceTransfer(SelectedAccount, long.Parse(TransferPanelAmount));

            }

            VisibilityTransferPanel = Visibility.Hidden;
            IsEnableButtonsPanel = true;
            IsEnableClientList = true;
            TransferButtonParams = "";
        }

        #endregion

        #region Команда подготовки к пополнению Аккаунта

        private bool CanAddBalancePrep(object parametr) => SelectedAccount != null;
        private void OnAddBalancePrep(object parametr)
        {
            IsEnableButtonsPanel = false;
            IsEnableClientList = false;
            TransferButtonText = "Пополнить";
            TransferPanelText = "Выберите счет для пополнения";
            VisibilityTransferPanel = Visibility.Visible;
            OutAccount = SelectedAccount.model;
            TransferPanelAmount = "0";
            TransferButtonParams = "AddBalance";

        }

        #endregion

        #region Команда подготовки к переводу на внешний Аккаунт

        private bool CanExrernalTransferPrep(object parametr) => 
            SelectedClient != null && SelectedAccount != null;
        private void OnExrernalTransferPrep(object parametr)
        {
            IsEnableButtonsPanel = false;
            TransferButtonText = "Перевести";
            TransferPanelText = "Выберите клиента и счет для перевода";
            VisibilityTransferPanel = Visibility.Visible;
            OutClient = SelectedClient;
            OutAccount = SelectedAccount.model;
            TransferButtonParams = "ExternalTransfer";

        }

        #endregion

    }
}