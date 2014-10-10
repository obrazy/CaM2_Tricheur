using CaM2___Le_Tricheur.Model.Grid;

namespace CaM2___Le_Tricheur.Model
{
	public class ModelFacade
	{
		#region Constants

		private const int SIZE = 4;

		#endregion

		#region Properties

		private static ModelFacade _instance;
		public static ModelFacade Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ModelFacade();
				}
				return _instance;
			}
		}

		private WordDictionary _dict;

		private GameGrid _grid;

		#endregion

		#region Constructors

		private ModelFacade()
		{
			this._dict = new WordDictionary();
			this._grid = new GameGrid(SIZE);
		}

		#endregion

		#region Methods

		public void LoadDictionaries()
		{
			this._dict.LoadWords();
		}

		public bool IsWord(string word)
		{
			return this._dict.IsWord(word);
		}

		public void SaveNewGrid(GameGrid g)
		{
			this._grid = new GameGrid(g);
		}

		public GameGrid QueryGrid()
		{
			return new GameGrid(this._grid);
		}

		#endregion
	}
}
