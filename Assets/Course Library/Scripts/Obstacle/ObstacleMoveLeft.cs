using UnityEngine;

namespace Course_Library.Scripts.Obstacle
{
    public class ObstacleMoveLeft : MonoBehaviour
    {
        private float _speed = 30.0f;

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.left * Time.deltaTime * _speed);
        }
    }
}
