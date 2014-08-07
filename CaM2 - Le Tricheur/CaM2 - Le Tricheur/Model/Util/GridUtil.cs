using CaM2___Le_Tricheur.Model.Grid;
using System.Collections.Generic;

namespace CaM2___Le_Tricheur.Model.Util
{
    public class GridUtil
    {
        #region Methods

        public static IList<Cell> GetConnectedCells(int row, int col, GameGrid g)
        {
            IList<Cell> connected = new List<Cell>();

            if (HasNorth(row))
            {
                connected.Add(GetNorth(row, col, g));
            }

            if (HasNorthEast(row, col))
            {
                connected.Add(GetNorthEast(row, col, g));
            }

            if (HasEast(col))
            {
                connected.Add(GetEast(row, col, g));
            }

            if (HasSouthEast(row, col))
            {
                connected.Add(GetSouthEast(row, col, g));
            }

            if (HasSouth(row))
            {
                connected.Add(GetSouth(row, col, g));
            }

            if (HasSouthWest(row, col))
            {
                connected.Add(GetSouthWest(row, col, g));
            }

            if (HasWest(col))
            {
                connected.Add(GetWest(row, col, g));
            }

            if (HasNorthWest(row, col))
            {
                connected.Add(GetNorthWest(row, col, g));
            }

            return connected;
        }

        /*public static IList<Cell> SerializeGridCells(GameGrid g)
        {
            IList<Cell> cells = new List<Cell>();

            for (int row = 0; row < GridConstants.N_ROWS; row++)
            {
                for(int col = 0; col < GridConstants.N_COLS; col++)
                {
                    cells.Add(g.Cells[row][col]);
                }
            }

            return cells;
        }*/

        private static bool HasNorth(int row)
        {
            return row > 0;
        }

        private static bool HasEast(int col)
        {
            return col < GridConstants.N_COLS - 1;
        }

        private static bool HasSouth(int row)
        {
            return row < GridConstants.N_ROWS - 1;
        }

        private static bool HasWest(int col)
        {
            return col > 0;
        }

        private static bool HasNorthEast(int row, int col)
        {
            return HasNorth(row) && HasEast(col);
        }

        private static bool HasSouthEast(int row, int col)
        {
            return HasSouth(row) && HasEast(col);
        }

        private static bool HasSouthWest(int row, int col)
        {
            return HasSouth(row) && HasWest(col);
        }

        private static bool HasNorthWest(int row, int col)
        {
            return HasNorth(row) && HasWest(col);
        }

        private static Cell GetNorth(int row, int col, GameGrid g)
        {
            return g.Cells[row - 1][col];
        }

        private static Cell GetNorthEast(int row, int col, GameGrid g)
        {
            return g.Cells[row - 1][col + 1];
        }

        private static Cell GetEast(int row, int col, GameGrid g)
        {
            return g.Cells[row][col + 1];
        }

        private static Cell GetSouthEast(int row, int col, GameGrid g)
        {
            return g.Cells[row + 1][col + 1];
        }

        private static Cell GetSouth(int row, int col, GameGrid g)
        {
            return g.Cells[row + 1][col];
        }

        private static Cell GetSouthWest(int row, int col, GameGrid g)
        {
            return g.Cells[row + 1][col - 1];
        }

        private static Cell GetWest(int row, int col, GameGrid g)
        {
            return g.Cells[row][col - 1];
        }

        private static Cell GetNorthWest(int row, int col, GameGrid g)
        {
            return g.Cells[row - 1][col - 1];
        }

        #endregion
    }
}
