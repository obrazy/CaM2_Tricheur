
namespace CaM2___Le_Tricheur.Model.Grid
{
    public class GameGrid
    {
        #region Properties

        public Cell[][] Cells { get; set; }

        #endregion

        #region Constructors

        public GameGrid()
        {
            Cells = new Cell[GridConstants.N_ROWS][];

            for (int row = 0; row < GridConstants.N_ROWS; row++)
            {
                Cells[row] = new Cell[GridConstants.N_COLS];

                for (int col = 0; col < GridConstants.N_COLS; col++)
                {
                    Cells[row][col] = new Cell(row, col);
                }
            }
        }

        public GameGrid(GameGrid g)
        {
            Cells = new Cell[GridConstants.N_ROWS][];

            for (int row = 0; row < GridConstants.N_ROWS; row++)
            {
                this.Cells[row] = new Cell[GridConstants.N_COLS];

                for (int col = 0; col < GridConstants.N_COLS; col++)
                {
                    this.Cells[row][col] = new Cell(g.Cells[row][col]);
                }
            }
        }

        #endregion
    }
}
