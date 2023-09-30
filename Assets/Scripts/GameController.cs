using UnityEngine;

namespace Assets.Scripts
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private string[] _initialGoodWords;

        private Data.Data _data;

        // Use this for initialization
        void Start()
        {
            _data = new Data.Data();

            GoodWordsSpawner spawner = new GoodWordsSpawner();
            spawner.SpawnWords(_initialGoodWords);
        }

    }
}