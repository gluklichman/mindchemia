using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class MatchWordsUi : MonoBehaviour
    {
        [SerializeField]
        private TMPro.TMP_Text _wordText1;
        [SerializeField]
        private TMPro.TMP_Text _wordText2;
        [SerializeField]
        private TMPro.TMP_Text _resultText;

        private WordMatchData _currentMatchDataState;

        // Use this for initialization
        void Start()
        {
            _currentMatchDataState = new WordMatchData();
            _wordText1.text = string.Empty;
            _wordText2.text = string.Empty;
            _resultText.text = string.Empty;
        }

        // Update is called once per frame
        void Update()
        {
            if (Data.Data.WordMatchData.FirstWordId != _currentMatchDataState.FirstWordId)
            {
                _wordText1.text = Data.Data.Configs.WordConfig.GetGoodWord(Data.Data.WordMatchData.FirstWordId).text;
                _currentMatchDataState.FirstWordId = Data.Data.WordMatchData.FirstWordId;
            }
            if (Data.Data.WordMatchData.SecondWordId != _currentMatchDataState.SecondWordId)
            {
                _wordText2.text = Data.Data.Configs.WordConfig.GetGoodWord(Data.Data.WordMatchData.SecondWordId).text;
                _currentMatchDataState.SecondWordId = Data.Data.WordMatchData.SecondWordId;
            }
            if (Data.Data.WordMatchData.ResultWordId != _currentMatchDataState.ResultWordId)
            {
                _resultText.text = Data.Data.Configs.WordConfig.GetGoodWord(Data.Data.WordMatchData.ResultWordId).text;
                _currentMatchDataState.ResultWordId = Data.Data.WordMatchData.ResultWordId;
            }
        }
    }
}