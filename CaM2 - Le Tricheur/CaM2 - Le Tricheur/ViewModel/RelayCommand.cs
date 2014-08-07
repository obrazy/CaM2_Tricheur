using System;
using System.Windows.Input;

namespace CaM2___Le_Tricheur.ViewModel
{
    class RelayCommand : ICommand
    {
        #region Properties

        private Action<object> _action;

        private Predicate<object> _canExecutePredicate;

        #endregion

        #region Constructors

        public RelayCommand(Action<object> action, Predicate<object> canExecutePredicate)
        {
            this._action = action;
            this._canExecutePredicate = canExecutePredicate;
        }

        #endregion

        #region ICommand Members

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return this._canExecutePredicate == null ? true : this._canExecutePredicate.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            this._action(parameter);
        }

        #endregion
    }
}
