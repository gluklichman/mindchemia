using System.Collections.Generic;
using UnityEngine;
using static WordConfig;

namespace Assets.Scripts.Logic
{
    public class WordsMatcher : MonoBehaviour
    {
        private List<string> _selectedWords = new List<string>();
        private string _currentMatchResult = string.Empty;
        private const int _wordsMatchCount = 2;

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null)
                {
                    GoodWord goodWord = hit.collider.GetComponent<GoodWord>();
                    if (goodWord != null)
                    {
                        HandleGoodWordClick(goodWord);
                    }
                }
            }
        }

        private void HandleGoodWordClick(GoodWord word)
        {
            if (_selectedWords.Count < _wordsMatchCount)
            {
                _selectedWords.Add(word.WordId);
                UpdateWordMatchData();
            }
            if (_selectedWords.Count == _wordsMatchCount)
            {
                TryMatchWords();
            }
            Debug.Log("Good word clicked: " + word.WordId);
        }

        private void UpdateWordMatchData()
        {
            Data.Data.WordMatchData.FirstWordId = _selectedWords.Count >= 1 ? _selectedWords[0] : string.Empty;
            Data.Data.WordMatchData.SecondWordId = _selectedWords.Count > 1 ? _selectedWords[1] : string.Empty;
            Data.Data.WordMatchData.ResultWordId = _currentMatchResult;
        }

        private void TryMatchWords()
        {
            WordData match = Data.Data.Configs.WordConfig.TryPerformMatch(_selectedWords[0], _selectedWords[1]);
            if (match != null)
            {
                Debug.Log($"Words {_selectedWords[0]} and {_selectedWords[1]} matched: {match.id}");
                _currentMatchResult = match.id;
                UpdateWordMatchData();
            }
        }
    }
}