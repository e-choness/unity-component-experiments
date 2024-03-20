using Course_Library.Scripts.ClassExtensions;
using UnityEngine;

namespace Challenge_3.Scripts
{
    public class BoundaryCheck : MonoBehaviour
    {
        private BoxCollider _collider;
        private Vector2 _screenBounds;
        private Vector2 _objectBounds;
        
        private void Start()
        {
            _collider = GetComponent<BoxCollider>();
            _objectBounds = _collider.size.ToVector2WithY()/2.0f;
            // _cameraHeight = Camera.main.OrthographicBounds().size.y;
            _screenBounds = Camera.main.OrthographicBounds().size;
        }

        private void Update()
        {
            ResetHeight();
        }

        private void ResetHeight()
        {
            // var halfColliderHeight = _collider.bounds.size.y / 2.0f;
            // var currentTopBound = transform.position.y + halfColliderHeight;
            var viewPosition = transform.position;

            // viewPosition = Mathf.Clamp(viewPosition, -_screenBounds + _objectBounds, _screenBounds - _objectBounds);
            viewPosition.x = Mathf.Clamp(viewPosition.x, _screenBounds.x * -1 + _objectBounds.x, _screenBounds.x - _objectBounds.x);
            viewPosition.y = Mathf.Clamp(viewPosition.y,_screenBounds.y * -1 + _objectBounds.y, _screenBounds.y - _objectBounds.y);
            transform.position = new Vector3(viewPosition.x, viewPosition.y, transform.position.z);
            
            
            Debug.Log($"Current top bound: {transform.position.y}, screen height {_screenBounds.y}");
        }
    }
}