using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaM2___Le_Tricheur.Model.Grid
{
    public class Cell
    {
        #region Properties

        public char Letter { get; set; }

        public int Row { get; set; }

        public int Col { get; set; }

        #endregion

        #region Constructors

        public Cell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
            this.Letter = '-';
        }

        #endregion
    }
}
