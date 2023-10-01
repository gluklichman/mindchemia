using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Logic
{
    public class GoodWord : MonoBehaviour
    {
        private TMPro.TMP_Text _text;
        private string _wordId;

        public string WordId => _wordId;

        public void Setup(string wordId)
        {
            _wordId = wordId;

            _text = GetComponentInChildren<TMPro.TMP_Text>();
            WordConfig.WordData wordData = Data.Data.Configs.WordConfig.GetGoodWord(_wordId);
            _text.text = wordData.text;
        }
    }
}