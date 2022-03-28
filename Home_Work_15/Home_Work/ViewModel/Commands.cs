using System.Threading;
using System.Threading.Tasks;
using Components;
using HomeWork.Entities;
using UseCases.Commands;

namespace HomeWork.ViewModel
{
    public partial class MainViewModel
    {
        #region Команда выход (Exit)

        private bool CanExitAppCommand(object parameter) => true;
        private void OnExitAppCommand(object parameter) => System.Windows.Application.Current.Shutdown();

        #endregion

        #region Команд подготовки к добавлению БА

        private bool CanAddAccount(object parametr) => ExtraPanelType == PanelType.None;
        private void OnAddAccoun(object parameter) => ExtraPanelType = PanelType.AddAccount;

        #endregion

        #region Команда создание обычного БА

        private bool CanCreateAccount(object parametr) => true;

        private void OnCreateAccount(object parameter)
        {
            var command = new AddSimpleAccountCommand.Command
            {
                Client = SelectedClient
            };

            _sender.Send(command);

            ExtraPanelType = PanelType.None;
        }

        #endregion

        #region Команда создание депозитного БА

        private bool CanCreateDepositAccount(object parametr) => true;

        private void OnCreateDepositAccount(object parameter)
        {
            var command = new AddDepositAccountCommand.Command
            {
                Client = SelectedClient
            };

            _sender.Send(command);

            ExtraPanelType = PanelType.None;
        }

        #endregion

        #region Команда удаление банковского счета

        private bool CanRemoveAccount(object parametr) =>
            SelectedAccount != null && ExtraPanelType == PanelType.None;

        private void OnRemoveAccount(object parameter)
        {
            var command = new RemoveAccountCommand.Command
            {
                Client = SelectedClient,
                Account = SelectedAccount.model
            };

            _sender.Send(command);
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

        private async void OnInternalAddBalance(object parametr)
        {
            var command = new AddBalanceAccountCommand.Command
            {
                Account = SelectedAccount,
                Amount = AamountTransfer
            };

            SelectedAccount.model = await _sender.Send(command);

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
            var command = new InternalTransferCommand.Command
            {
                From = OutAccount,
                To = SelectedAccount,
                Amount = AamountTransfer
            };

            _sender.Send(command);
            
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
            var command = new InternalTransferCommand.Command
            {
                From = OutAccount,
                To = SelectedAccount,
                Amount = AamountTransfer
            };

            _sender.Send(command);

            ExtraPanelType = PanelType.None;

        }

        #endregion

    }
}