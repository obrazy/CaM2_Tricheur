
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
            : this(row, col, '-')
        {
        }

        public Cell(int row, int col, char letter)
        {
            this.Row = row;
            this.Col = col;
            //this.Letter = letter;

            // TEMP //////
            if(row == 2 && col == 3)
            {
                this.Letter = 'B';
            }
            else
            {
                this.Letter = letter;
            }

            //////////////
        }

        public Cell(Cell c)
        {
            this.Row = c.Row;
            this.Col = c.Col;
            this.Letter = c.Letter;
        }

        #endregion
    }
}
