using CaM2___Le_Tricheur.Model;
using System.Windows;

namespace CaM2___Le_Tricheur
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ModelFacade.Instance.LoadDictionaries();
            base.OnStartup(e);
        }
    }
}
