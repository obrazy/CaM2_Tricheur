using System.ComponentModel;

namespace CaM2___Le_Tricheur.ViewModel
{
	public class ViewModelBase : INotifyPropertyChanged
	{
		#region Methods

		public void NotifyPropertyChanged(string propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		#endregion

		#region INotifyPropertyChanged Members

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion
	}
}
