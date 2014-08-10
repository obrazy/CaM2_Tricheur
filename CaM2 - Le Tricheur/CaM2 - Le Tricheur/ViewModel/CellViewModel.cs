using CaM2___Le_Tricheur.Model;
using CaM2___Le_Tricheur.Model.Grid;

namespace CaM2___Le_Tricheur.ViewModel
{
    public class CellViewModel : ViewModelBase
    {
        #region Properties

        private Cell _cell;
        public Cell Cell
        {
            get
            {
                return this._cell;
            }
        }

        public int Row
        {
            get
            {
                return this._cell.Row;
            }
        }

        public int Col
        {
            get
            {
                return this._cell.Col;
            }
        }

        public char Letter
        {
            get
            {
                return this._cell.Letter;
            }
            set
            {
                this._cell.Letter = value;
                this.NotifyPropertyChanged("Letter");
            }
        }

        #endregion

        #region Constructors

        public CellViewModel(Cell c)
        {
            this._cell = c;
        }

        #endregion
    }
}
