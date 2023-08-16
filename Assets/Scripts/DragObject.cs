using UnityEngine;
using UnityEngine.InputSystem;
public class DragObject : MonoBehaviour
{
    private InputAction _press;
    private InputAction _screenPosition;
    // private Vector3 _offset;
    //
    // private float _zCoordinate;
    // private void OnMouseDown()
    // {
    //     if (Camera.main != null) _zCoordinate = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
    //     _offset = gameObject.transform.position - GetMouseWorldPos();
    // }
    //
    // private void OnMouseDrag()
    // {
    //     transform.position = GetMouseWorldPos() + _offset;
    // }
    //
    // private Vector3 GetMouseWorldPos()
    // {
    //     Vector3 mousePoint = Input.mousePosition;
    //     mousePoint.z = _zCoordinate;
    //     return Camera.main.ScreenToViewportPoint(mousePoint);
    // }


}
