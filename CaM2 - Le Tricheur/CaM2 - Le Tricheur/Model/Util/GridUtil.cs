using CaM2___Le_Tricheur.Model.Grid;
using System.Collections.Generic;

namespace CaM2___Le_Tricheur.Model.Util
{
	public class GridUtil
	{
		#region Methods

		public static List<Cell> GetConnectedCells(Cell c, GameGrid g)
		{
			List<Cell> connected = new List<Cell>();

			for (int row = c.Row - 1; row <= c.Row + 1; row++)
			{
				if (row < 0 || row > g.Size - 1)
				{
					continue;
				}

				for (int col = c.Col - 1; col <= c.Col + 1; col++)
				{
					if (col < 0 || col > g.Size - 1 || (row == c.Row && col == c.Col))
					{
						continue;
					}

					connected.Add(g.Cells[row][col]);
				}
			}

			return connected;
		}

		#endregion
	}
}
