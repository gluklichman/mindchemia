using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Moving
{
    public class GoodWordMover : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 1f;

        private Vector3 _speedVector;
        private BoxCollider2D _boxCollider;

        // Use this for initialization
        void Start()
        {
            _boxCollider = GetComponent<BoxCollider2D>();
        }

        public void Setup(Vector3 _initialSpeedDirection)
        {
            _speedVector = _initialSpeedDirection.normalized * _speed; 
        }

        // Update is called once per frame
        private void Update()
        {
            if ((transform.position - Vector3.zero).sqrMagnitude >= 64)
            {
                Vector3 centerDirection = (transform.position - Vector3.zero).normalized;
                Vector3 newSpeedVector = Random.insideUnitCircle.normalized * _speed;
                if (Vector3.Dot(centerDirection, newSpeedVector) > 0)
                {
                    newSpeedVector = -newSpeedVector;
                }
                _speedVector = newSpeedVector;
            }
            transform.position += _speedVector * Time.deltaTime;
        }
    }
}