using UnityEngine;

namespace Course_Library.Scripts.Perspective
{
    public class RotateCamera : MonoBehaviour
    {
        [Header("Input Properties")] 
        [SerializeField] private float rotationSpeed = 15.0f;
    
        // Input mapping
        private static float HorizontalInput => Input.GetAxis("Horizontal");
        // private static float VerticalInput => Input.GetAxis("Vertical");

        // Update is called once per frame
        private void Update()
        {
            RotateHorizontally();
        }

        private void RotateHorizontally()
        {
            transform.Rotate(Vector3.up, HorizontalInput*rotationSpeed*Time.deltaTime);
        }
    }
}
