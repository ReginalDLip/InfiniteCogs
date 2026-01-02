using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Drag Player ke sini
    public float smoothSpeed = 0.3f; // Kehalusan gerakan

    void LateUpdate()
    {
      
        if (target.position.y > transform.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, smoothSpeed);
        }
    }
}