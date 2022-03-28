using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using Models.Base;
using Models.Interfaces;
using Newtonsoft.Json;
using View.Dialog;

namespace Presenter;

public partial class Presenter
{
    #region AddAnimal

    public ICommand AddAmimalCommand { get; }

    private bool CanAddAnimal(object parameter) => true;

    private void OnAddAnimal(object parameter)
    {
        var type = parameter as string;

        if (type == null) return;

        switch (type)
        {
            case "mammals": Repository.Add(_model.CreateAnimal(AnimalType.MAMMALS)); break;
            case "birds": Repository.Add(_model.CreateAnimal(AnimalType.BIRDS)); break;
            case "amphibious": Repository.Add(_model.CreateAnimal(AnimalType.AMPHIBIOUS)); break;
            default: return;
        }

    }

    #endregion

    #region RemoveAnimal

    public ICommand RemoveAmimalCommand { get; }

    private bool CanRemoveAnimal(object parameter) => true;

    private void OnRemoveAnimal(object parameter)
    {
       if (CurentAnimal is null) return;

       Repository.Remove(CurentAnimal);
    }

    #endregion

    #region RenameAnimal

    public ICommand OpenDialogCommand { get; }

    private bool CanOpenDialog(object parameter) => true;

    private async void OnOpenDialog(object parameter)
    {
        var view = new RenameDialog()
        {
            DataContext = this 
        };

        await DialogHost.Show(view, "root", ClosingEventHandler);
    }

    private void ClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
    
    {
        if ((bool) eventArgs.Parameter!)
        {
            var dialogText = 
                ((eventArgs.Source as DialogHost)
                    .DialogContent as RenameDialog)
                .TxtName.Text;

            if (dialogText.Length < 20 && !String.IsNullOrWhiteSpace(dialogText))
            {
                Repository.Remove(CurentAnimal);
                CurentAnimal.Name = dialogText;
                Repository.Add(CurentAnimal);
            }
        }
    }

    #endregion

    #region SaveCommand

    public ICommand SaveDbCommand { get; }

    private bool CanSaveDb(object parameter) => true;

    private async void OnSaveDb(object parameter)
    {
        if (Repository is null) return;
        
        var storage = JsonConvert.SerializeObject(Repository, Formatting.Indented, 
            new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        });

       await File.WriteAllTextAsync(@"database.txt", storage);
        
    }

    #endregion

    #region LoadCommand

    public ICommand LoadDbCommand { get; }

    private bool CanLoadDb(object parameter) => true;

    private async void OnLoadDb(object parameter)
    {
        Repository.Clear();

        var text = await File.ReadAllTextAsync(@"database.txt");

        var data = JsonConvert.DeserializeObject<ObservableCollection<IAnimal>>(
            text, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });

        foreach (var animal in data)
        {
            Repository.Add(animal);
        }

    }


    #endregion

}