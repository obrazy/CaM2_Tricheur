using System.Collections.Generic;

namespace CaM2___Le_Tricheur.Model.Grid
{
    public class GameGrid
    {
        #region Properties

        public int Size { get; set; }
        public Cell[][] Cells { get; set; }
        /*public IList<Cell> CellsSerialized
        {
            get
            {
                IList<Cell> serialized = new List<Cell>();

                for (int row = 0; row < this.Size; row++)
                {
                    for (int col = 0; col < this.Size; col++)
                    {
                        serialized.Add(this.Cells[row][col]);
                    }
                }

                return serialized;
            }
        }*/

        private SortedSet<Word> _words;
        public SortedSet<Word> Words
        {
            get
            {
                return this._words;
            }
        }

        #endregion

        #region Constructors

        public GameGrid(int size)
        {
            this.Size = size;
            this.Cells = new Cell[size][];

            for (int row = 0; row < size; row++)
            {
                Cells[row] = new Cell[size];

                for (int col = 0; col < size; col++)
                {
                    Cells[row][col] = new Cell(row, col);
                }
            }
        }

        public GameGrid(GameGrid g)
        {
            this.Size = g.Size;
            this.Cells = new Cell[this.Size][];

            for (int row = 0; row < this.Size; row++)
            {
                this.Cells[row] = new Cell[this.Size];

                for (int col = 0; col < this.Size; col++)
                {
                    this.Cells[row][col] = new Cell(g.Cells[row][col]);
                }
            }
        }

        public GameGrid(int size, IList<Cell> cells)
        {
            this.Size = size;
            this.Cells = new Cell[size][];

            int currentIndex = 0;

            for (int row = 0; row < size; row++)
            {
                Cells[row] = new Cell[size];

                for (int col = 0; col < size; col++)
                {
                    Cells[row][col] = new Cell(cells[currentIndex]);
                    currentIndex++;
                }
            }
        }

        #endregion

        #region Methods

        public void FindWords()
        {
            System.Threading.Thread.Sleep(2000);
        }

        public bool IsValid()
        {
            for(int row = 0; row < this.Size; row++)
            {
                for(int col = 0; col < this.Size; col++)
                {
                    if (!char.IsLetter(this.Cells[row][col].Letter))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        #endregion
    }
}
