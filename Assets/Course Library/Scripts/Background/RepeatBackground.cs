using UnityEngine;

namespace Course_Library.Scripts.Background
{
    public class RepeatBackground : MonoBehaviour
    {
        private Vector3 _startPosition;

        private float _repeatWidth;
        // Start is called before the first frame update
        private void Start()
        {
            _startPosition = transform.position;
            _repeatWidth = GetComponent<BoxCollider>().size.x / 2;
        }

        // Update is called once per frame
        private void Update()
        {
            if (transform.position.x < _startPosition.x - _repeatWidth)
            {
                transform.position = _startPosition;
            }
        }
    }
}
