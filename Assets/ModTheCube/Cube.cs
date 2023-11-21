using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.localScale = Vector3.one * 1.3f;
        
        Material material = Renderer.material;
        
        material.color = new Color(0.7f, 0.0f, 0.7f, 0.4f);
    }
    
    void Update()
    {
        StartCoroutine(RotateCubeAtRandom());
    }

    IEnumerator RotateCubeAtRandom()
    {
        // Randomly generate x, y, z angle for the cube to rotate every frame.
        var xAngle = Random.Range(6.0f, 10.0f);
        var yAngle = Random.Range(1.0f, 5.0f);
        var zAngle = Random.Range(4.0f, 6.0f);
        
        // Rotate cube
        transform.Rotate(xAngle * Time.deltaTime, yAngle, zAngle);
        yield return new WaitForSeconds(3);
    }
}
