using System;
using System.Collections.Generic;

namespace CaM2___Le_Tricheur.Model.Grid
{
	public class Answer : IComparable<Answer>
	{
		#region Properties

		public string Word { get; set; }

		public int Length
		{
			get
			{
				return this.Word.Length;
			}
		}

		public IList<Cell> Path { get; set; }

		#endregion

		#region Constructors

		public Answer(string s, IList<Cell> cells)
		{
			this.Word = s;

			this.Path = new List<Cell>();

			foreach (Cell c in cells)
			{
				this.Path.Add(new Cell(c));
			}
		}

		#endregion

		#region IComparable Members

		public int CompareTo(Answer other)
		{
			if (this.Length == other.Length)
			{
				return this.Word.CompareTo(other.Word);
			}
			else if (this.Length > other.Length)
			{
				return -1;
			}
			else
			{
				return 1;
			}
		}

		#endregion
	}
}
