using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class DragObject : MonoBehaviour
{
    
    private InputAction _pressActionMap;
    private InputAction _screenPositionActionMap;
    private Rigidbody _rigidbody;
    
    private Camera camera;
    private Vector3 _cursorScreenPosition;

    private Vector3 _worldPosition
    {
        get
        {
            float z = camera.WorldToScreenPoint(transform.position).z;
            return camera.ScreenToWorldPoint(_cursorScreenPosition + new Vector3(0, 0, z));
        }
    }
    private bool _isDragging;
    private bool _isClickedOn
    {
        get
        {
            Ray ray = camera.ScreenPointToRay(_cursorScreenPosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                return hit.transform == transform;
            }
            return false;
        }
    }
    

    private void Awake()
    {
        camera = Camera.main;
        var inputAction = new InputController();
        _pressActionMap = inputAction.MouseDragDrop.Press;
        _screenPositionActionMap = inputAction.MouseDragDrop.ScreenPosition;
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _pressActionMap.Enable();
        _screenPositionActionMap.Enable();

        _screenPositionActionMap.performed += context => { _cursorScreenPosition = context.ReadValue<Vector2>(); };
        _pressActionMap.performed += _ => { if(_isClickedOn)StartCoroutine(DragCursor()); };
        _pressActionMap.canceled += _ => { _isDragging = false; };
    }

    private IEnumerator DragCursor()
    {
        _isDragging = true;
        Vector3 offset = transform.position - _worldPosition;
        // Starts to drag objects
        _rigidbody.useGravity = true;
        while (_isDragging)
        {
            // Dragging objects
            transform.position = _worldPosition + offset;
            yield return null;
        }
        // Dropping objects
        _rigidbody.useGravity = false;
    }

}
