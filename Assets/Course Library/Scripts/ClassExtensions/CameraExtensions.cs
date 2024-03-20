using UnityEngine;

namespace Course_Library.Scripts.ClassExtensions
{
    public static class CameraExtensions
    {
        public static Bounds OrthographicBounds(this Camera camera)
        {
            float screenAspect = Screen.width / (float)Screen.height;
            float cameraHeight = camera.orthographicSize * 2;
            Bounds bounds = new Bounds(
                camera.transform.position,
                new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
            return bounds;
        }

        public static Vector3 ScreenBounds(this Camera camera)
        {
            return camera.ScreenToWorldPoint(
                new Vector3(
                    Screen.width, 
                    Screen.height, 
                    camera.transform.position.z));
        }
        
        public static Vector2 BoundsMin(this Camera camera)
        {
            return camera.transform.position.ToVector2WithY() - camera.Extents();
        }
	
        public static Vector2 BoundsMax(this Camera camera)
        {
            return camera.transform.position.ToVector2WithY() + camera.Extents();
        }
	
        public static Vector2 Extents(this Camera camera)
        {
            if (camera.orthographic)
                return new Vector2(camera.orthographicSize * Screen.width/Screen.height, camera.orthographicSize);
            else
            {
                Debug.LogError("Camera is not orthographic!", camera);
                return new Vector2();
            }
        }
    }
}

