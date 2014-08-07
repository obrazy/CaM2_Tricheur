using CaM2___Le_Tricheur.Model;
using CaM2___Le_Tricheur.Model.Grid;
using System.Collections.ObjectModel;

namespace CaM2___Le_Tricheur.ViewModel
{
    public class GameGridViewModel : ViewModelBase
    {
        #region Properties

        public int NRows
        {
            get
            {
                return GridConstants.N_ROWS;
            }
        }

        public int NCols
        {
            get
            {
                return GridConstants.N_COLS;
            }
        }

        private ObservableCollection<CellViewModel> _cells;
        public ObservableCollection<CellViewModel> Cells
        {
            get
            {
                if(this._cells == null)
                {
                    this._cells = new ObservableCollection<CellViewModel>();

                    for(int row = 0; row < this.NRows; row++)
                    {
                        for(int col = 0; col < this.NCols; col++)
                        {
                            this._cells.Add(new CellViewModel(row, col));
                        }
                    }
                }

                return this._cells;
            }
        }

        #endregion

        #region Constructors

        public GameGridViewModel()
        {
            // TODO
        }

        #endregion

        #region Methods
        #endregion
    }
}
