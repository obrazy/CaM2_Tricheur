
namespace CaM2___Le_Tricheur.Model.Grid
{
	public class Cell
	{
		#region Properties

		private char _letter;
		public char Letter
		{
			get
			{
				return this._letter;
			}
			set
			{
				char tmp = value;

				if (char.IsLetter(tmp))
				{
					byte[] tempBytes;
					tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(new string(tmp, 1));
					tmp = char.ToUpper(System.Text.Encoding.UTF8.GetString(tempBytes).ToCharArray()[0]);
				}

				this._letter = tmp;
			}
		}

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
			this.Letter = letter;
		}

		public Cell(Cell c)
		{
			this.Row = c.Row;
			this.Col = c.Col;
			this.Letter = c.Letter;
		}

		#endregion

		#region Object Members

		public override bool Equals(object obj)
		{
			var newObj = obj as Cell;

			if (newObj == null)
			{
				return base.Equals(obj);
			}
			else
			{
				return newObj.Letter == this.Letter && newObj.Row == this.Row && newObj.Col == this.Col;
			}
		}

		#endregion
	}
}
