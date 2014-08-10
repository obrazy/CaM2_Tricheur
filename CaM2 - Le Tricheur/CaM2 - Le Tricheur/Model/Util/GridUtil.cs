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

            if (HasNorth(row, g.Size))
            {
                connected.Add(GetNorth(row, col, g));
            }

            if (HasNorthEast(row, col, g.Size))
            {
                connected.Add(GetNorthEast(row, col, g));
            }

            if (HasEast(col, g.Size))
            {
                connected.Add(GetEast(row, col, g));
            }

            if (HasSouthEast(row, col, g.Size))
            {
                connected.Add(GetSouthEast(row, col, g));
            }

            if (HasSouth(row, g.Size))
            {
                connected.Add(GetSouth(row, col, g));
            }

            if (HasSouthWest(row, col, g.Size))
            {
                connected.Add(GetSouthWest(row, col, g));
            }

            if (HasWest(col, g.Size))
            {
                connected.Add(GetWest(row, col, g));
            }

            if (HasNorthWest(row, col, g.Size))
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

        private static bool HasNorth(int row, int size)
        {
            return row > 0;
        }

        private static bool HasEast(int col, int size)
        {
            return col < size - 1;
        }

        private static bool HasSouth(int row, int size)
        {
            return row < size - 1;
        }

        private static bool HasWest(int col, int size)
        {
            return col > 0;
        }

        private static bool HasNorthEast(int row, int col, int size)
        {
            return HasNorth(row, size) && HasEast(col, size);
        }

        private static bool HasSouthEast(int row, int col, int size)
        {
            return HasSouth(row, size) && HasEast(col, size);
        }

        private static bool HasSouthWest(int row, int col, int size)
        {
            return HasSouth(row, size) && HasWest(col, size);
        }

        private static bool HasNorthWest(int row, int col, int size)
        {
            return HasNorth(row, size) && HasWest(col, size);
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
