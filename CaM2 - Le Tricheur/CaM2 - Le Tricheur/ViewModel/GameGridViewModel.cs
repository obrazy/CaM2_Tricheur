using CaM2___Le_Tricheur.Model;
using CaM2___Le_Tricheur.Model.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace CaM2___Le_Tricheur.ViewModel
{
    public class GameGridViewModel : ViewModelBase
    {
        #region Properties

        private GameGrid _grid;

        public int Size
        {
            get
            {
                if (this._grid == null)
                {
                    this._grid = ModelFacade.Instance.QueryGrid();
                }

                return this._grid.Size;
            }
        }

        private ObservableCollection<CellViewModel> _cellsSerialized;
        public ObservableCollection<CellViewModel> CellsSerialized
        {
            get
            {
                if (this._cellsSerialized == null)
                {
                    if (this._grid == null)
                    {
                        this._grid = ModelFacade.Instance.QueryGrid();
                    }

                    this._cellsSerialized = new ObservableCollection<CellViewModel>();

                    for (int row = 0; row < this.Size; row++)
                    {
                        for (int col = 0; col < this.Size; col++)
                        {
                            this._cellsSerialized.Add(new CellViewModel(this._grid.Cells[row][col]));
                        }
                    }
                }

                return this._cellsSerialized;
            }
        }

        private ObservableCollection<CellViewModel> _newGridCellsSerialized;
        public ObservableCollection<CellViewModel> NewGridCellsSerialized
        {
            get
            {
                if (this._newGridCellsSerialized == null)
                {
                    this._newGridCellsSerialized = new ObservableCollection<CellViewModel>();

                    for (int row = 0; row < this.Size; row++)
                    {
                        for (int col = 0; col < this.Size; col++)
                        {
                            this._newGridCellsSerialized.Add(new CellViewModel(new Cell(row, col)));
                        }
                    }
                }

                return this._newGridCellsSerialized;
            }
        }

        private bool _isSearching;
        public bool IsSearching
        {
            get
            {
                return this._isSearching;
            }
            set
            {
                this._isSearching = value;
                this.NotifyPropertyChanged("IsSearching");
            }
        }

        private BackgroundWorker _worker;

        private ObservableCollection<Answer> _answers;
        public ObservableCollection<Answer> Answers
        {
            get
            {
                if(this._answers == null)
                {
                    if(this._grid == null || this._grid.Words == null)
                    {
                        return null;
                    }

                    this._answers = new ObservableCollection<Answer>();

                    foreach (Answer a in this._grid.Words)
                    {
                        this._answers.Add(a);
                    }
                }

                return this._answers;
            }
        }

        //public ICommand NewGridCommand { get; set; }

        #endregion

        #region Constructors

        public GameGridViewModel()
        {
            this.IsSearching = false;

            this._worker = new BackgroundWorker();
            this._worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            this._worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);

            //this.ResetNewGrid();
            //this.NewGridCommand = new RelayCommand(new Action<object>(this.CreateNewGrid), x => true);
        }

        #endregion

        #region Methods

        public bool CreateNewGrid()
        {
            this.IsSearching = true;

            IList<Cell> newCells = new List<Cell>();

            foreach (CellViewModel cvm in this.NewGridCellsSerialized)
            {
                newCells.Add(cvm.Cell);
            }

            GameGrid newGrid = new GameGrid(this.Size, newCells);

            if (!newGrid.IsValid())
            {
                this.IsSearching = false;
                return false;
            }

            this._answers = null;
            this.NotifyPropertyChanged("Answers");

            ModelFacade.Instance.SaveNewGrid(newGrid);
            this._grid = null;
            this._cellsSerialized = null;
            this._newGridCellsSerialized = null;
            this.NotifyPropertyChanged("CellsSerialized");
            this.NotifyPropertyChanged("NewGridCellsSerialized");

            this._worker.RunWorkerAsync();

            return true;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this._grid != null)
            {
                this._grid.FindWords();
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.IsSearching = false;
            this.NotifyPropertyChanged("Answers");
        }

        /*private void ResetNewGrid()
        {
            this._newGridCellsSerialized = new ObservableCollection<CellViewModel>();

            for (int row = 0; row < this.Size; row++)
            {
                for (int col = 0; col < this.Size; col++)
                {
                    Cell tmpCell = new Cell(row, col);
                    CellViewModel tmpCvm = new CellViewModel(tmpCell);
                    this._newGridCellsSerialized.Add(tmpCvm);
                }
            }
        }*/

        #endregion
    }
}
