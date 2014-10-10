using CaM2___Le_Tricheur.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CaM2___Le_Tricheur.View
{
	/// <summary>
	/// Interaction logic for GameView.xaml
	/// </summary>
	public partial class GameView : UserControl
	{
		public GameView()
		{
			InitializeComponent();
		}

		private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
		{
			this.Popup_NewGrid.Visibility = System.Windows.Visibility.Hidden;
			this.MainArea.Visibility = Visibility.Visible;
			((sender as Button).DataContext as GameGridViewModel).ResetNewGrid();
		}

		private void Btn_NewGrid_Click(object sender, RoutedEventArgs e)
		{
			this.Popup_NewGrid.Visibility = System.Windows.Visibility.Visible;
			this.MainArea.Visibility = Visibility.Hidden;

			this.FocusFirstCell();
		}

		private void Btn_Accept_Click(object sender, RoutedEventArgs e)
		{
			if (((sender as Button).DataContext as GameGridViewModel).CreateNewGrid())
			{
				this.Popup_NewGrid.Visibility = System.Windows.Visibility.Hidden;
				this.MainArea.Visibility = Visibility.Visible;
			}
			else
			{
				string errorCaption = "Grille invalide";
				string errorText = "La grille entrée est invalide. La grille ne peut contenir que des lettres.";
				MessageBoxButton errorButton = MessageBoxButton.OK;
				MessageBoxImage errorImage = MessageBoxImage.Error;

				MessageBox.Show(errorText, errorCaption, errorButton, errorImage);
			}
		}

		private void TextBox_GotFocus(object sender, RoutedEventArgs e)
		{
			(sender as TextBox).SelectAll();
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			var request = new TraversalRequest(FocusNavigationDirection.Next);
			request.Wrapped = true;
			(sender as TextBox).MoveFocus(request);
		}

		private void FocusFirstCell()
		{
			ContentPresenter cp = this.InputGrid.ItemContainerGenerator.ContainerFromIndex(0) as ContentPresenter;
			TextBox tb = FindVisualChild<TextBox>(cp);
			if (tb != null)
			{
				tb.Focus();
			}
		}

		public static T FindVisualChild<T>(DependencyObject depObj) where T : DependencyObject
		{
			if (depObj != null)
			{
				for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
				{
					DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
					if (child != null && child is T)
					{
						return (T)child;
					}

					T childItem = FindVisualChild<T>(child);
					if (childItem != null) return childItem;
				}
			}
			return null;
		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			this.FocusFirstCell();
		}
	}
}
