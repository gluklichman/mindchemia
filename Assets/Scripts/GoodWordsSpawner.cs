using Assets.Scripts.Logic;
using Assets.Scripts.Moving;
using UnityEngine;

namespace Assets.Scripts
{
    public class GoodWordsSpawner
    {
        private const float _spawnRadius = 8;
        private GameObject _goodWordPrefab;

        public GoodWordsSpawner()
        {
            _goodWordPrefab = Resources.Load("Prefabs/GoodWord") as GameObject;
        }

        public void SpawnWords(string[] wordsList)
        {
            foreach (string word in wordsList)
            {
                SpawnSingleWord(word);
            }
        }

        private void SpawnSingleWord(string wordId)
        {
            GameObject wordObj = Object.Instantiate(_goodWordPrefab);
            Vector2 position = Random.insideUnitCircle * _spawnRadius;
            wordObj.transform.position = new Vector3(position.x, position.y, wordObj.transform.position.z);

            wordObj.GetComponent<GoodWord>().Setup(wordId);
            wordObj.GetComponent<GoodWordMover>().Setup(Random.insideUnitCircle);
        }
    }
}