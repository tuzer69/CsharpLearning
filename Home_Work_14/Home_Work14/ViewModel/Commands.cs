using System.Globalization;
using System.Windows;
using Components;
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

        private bool CanAddAccount(object parametr) => ExtraPanelType == PanelType.None;
        private void OnAddAccoun(object parameter) => ExtraPanelType = PanelType.AddAccount;

        #endregion

        #region Команда создание обычного БА

        private bool CanCreateAccount(object parametr) => true;

        private void OnCreateAccount(object parameter)
        {
            IClient tmpClient = SelectedClient;

            tmpClient.AddSimpleAccount();

            ExtraPanelType = PanelType.None;
        }

        #endregion

        #region Команда создание депозитного БА

        private bool CanCreateDepositAccount(object parametr) => true;

        private void OnCreateDepositAccount(object parameter)
        {
            IClient tmpClient = SelectedClient;

            tmpClient.AddDepositAccount();

            ExtraPanelType = PanelType.None;
        }

        #endregion

        #region Команда удаление банковского счета

        private bool CanRemoveAccount(object parametr) =>
            SelectedAccount != null && ExtraPanelType == PanelType.None;

        private void OnRemoveAccount(object parameter)
        {
            IClient tmpClient = SelectedClient;
            tmpClient.RemoveAccount(SelectedAccount.model);

        }

        #endregion

        #region Команда подготовки к пополнению Аккаунта

        private bool CanAddBalancePrep(object parametr) =>
            SelectedAccount != null && ExtraPanelType == PanelType.None;

        private void OnAddBalancePrep(object parametr)
        {
            ExtraPanelType = PanelType.TrasferMoney;
            OutAccount = SelectedAccount;
            ActiveCommand = InternalAddBalance;

        }

        #endregion

        #region Команда пополнения БА

        private bool CanInternalAddBalance(object parametr) => true;

        private void OnInternalAddBalance(object parametr)
        {

            IAccount tmpAccount = OutAccount;

            IAccount tmpAddBalance = SelectedAccount;

            tmpAddBalance = tmpAddBalance.AddBalance(AamountTransfer);

            ExtraPanelType = PanelType.None;
        }


        #endregion

        #region Команда подготовки к переводу на свой Аккаунт

        private bool CanInternalTransferPrep(object parametr) =>
            SelectedAccount != null && ExtraPanelType == PanelType.None;

        private void OnInternalTransferPrep(object parametr)
        {
            ExtraPanelType = PanelType.TrasferMoney;
            OutAccount = SelectedAccount;
            ActiveCommand = BalanceTransfer;

        }

        #endregion

        #region Команда перевода на свой Аккаунт

        private bool CanBalanceTransfer(object parametr)
        {
            if (SelectedAccount != null)
                return !SelectedAccount.Equals(OutAccount);
            return false;
        }

        private void OnBalanceTransfer(object parametr)
        {

            IAccount tmpAccount = OutAccount;

            tmpAccount.BalanceTransfer(SelectedAccount, AamountTransfer);

            ExtraPanelType = PanelType.None;

        }

        #endregion

        #region Команда подготовки к переводу на внешний Аккаунт

        private bool CanExrernalTransferPrep(object parametr) =>
            SelectedAccount != null && ExtraPanelType == PanelType.None;

        private void OnExrernalTransferPrep(object parametr)
        {
            ExtraPanelType = PanelType.TrasferMoney;
            ActiveCommand = ExternalTransfer;
            OutClient = SelectedClient;
            OutAccount = SelectedAccount;

        }

        #endregion

        #region Команда перевода на внешний акаунт Аккаунт

        private bool CanExternalTransfer(object parametr)
        {
            if (SelectedClient != null)
                return !SelectedClient.Equals(OutClient) && SelectedAccount != null;
            return false;
        }

        private void OnExternalTransfer(object parametr)
        {
            IAccount tmpAccount = OutAccount;

            tmpAccount.ExternalTransfer(SelectedAccount, AamountTransfer);

            ExtraPanelType = PanelType.None;

        }

        #endregion

    }
}