using CaM2___Le_Tricheur.Model;
using CaM2___Le_Tricheur.Model.Grid;

namespace CaM2___Le_Tricheur.ViewModel
{
    public class CellViewModel : ViewModelBase
    {
        #region Properties

        private Cell _cell;

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
        }

        #endregion

        #region Constructors

        public CellViewModel(int row, int col)
        {
            this._cell = ModelFacade.Instance.QueryCell(row, col);
        }

        #endregion
    }
}
