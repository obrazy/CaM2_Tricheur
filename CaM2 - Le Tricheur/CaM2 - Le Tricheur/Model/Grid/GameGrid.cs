using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        #endregion
    }
}
