
namespace CaM2___Le_Tricheur.Model
{
    public class ModelFacade
    {
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
        public WordDictionary Dictionary
        {
            get
            {
                return this._dict;
            }
        }

        #endregion

        #region Constructors

        private ModelFacade()
        {
            this._dict = new WordDictionary();
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

        #endregion
    }
}
