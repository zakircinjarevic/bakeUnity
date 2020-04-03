using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.2f;
    public Vector3 offset = new Vector3(-2f, 0f, -1f);

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        if (smoothedPosition.y > 0)
        { 
            transform.position = smoothedPosition;
        }
        else if(smoothedPosition.y < 0)
        {
            transform.position = new Vector3(smoothedPosition.x, 0f, smoothedPosition.z);
        }
    }
}
