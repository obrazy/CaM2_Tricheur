using CaM2___Le_Tricheur.Model.Util;
using System.Collections.Generic;

namespace CaM2___Le_Tricheur.Model.Grid
{
	public class GameGrid
	{
		#region Properties

		public int Size { get; set; }
		public Cell[][] Cells { get; set; }

		private SortedSet<Answer> _words;
		public SortedSet<Answer> Words
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
			this._words = new SortedSet<Answer>();

			for (int row = 0; row < this.Size; row++)
			{
				for (int col = 0; col < this.Size; col++)
				{
					List<Answer> words = new List<Answer>();
					List<Cell> path = new List<Cell>();
					path.Add(this.Cells[row][col]);

					this.FindWords(this.Cells[row][col], path, this.Cells[row][col].Letter.ToString(), words);

					this._words.UnionWith(words);
				}
			}
		}

		private void FindWords(Cell currentCell, List<Cell> path, string currentWord, IList<Answer> words)
		{
			if (currentWord.Length >= 3)
			{
				if (ModelFacade.Instance.IsWord(currentWord))
				{
					words.Add(new Answer(currentWord, path));
				}
			}

			if (currentWord.Length >= 10)
			{
				return;
			}

			List<Cell> neighbors = GridUtil.GetConnectedCells(currentCell, this);

			neighbors.RemoveAll(path.Contains);

			foreach (Cell c in neighbors)
			{
				List<Cell> newPath = new List<Cell>(path);
				newPath.Add(c);
				string newWord = currentWord + c.Letter.ToString();

				this.FindWords(c, newPath, newWord, words);
			}
		}

		public bool IsValid()
		{
			for (int row = 0; row < this.Size; row++)
			{
				for (int col = 0; col < this.Size; col++)
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
