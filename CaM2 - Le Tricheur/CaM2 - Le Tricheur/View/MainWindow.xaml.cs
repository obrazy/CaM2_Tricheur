using CaM2___Le_Tricheur.Model;
using System.Windows;

namespace CaM2___Le_Tricheur
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WordDictionary wd = new WordDictionary();
            wd.LoadWords();
            System.Threading.Thread.Sleep(2000);
        }
    }
}
