
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;

    public Vector3 offset;


   void LateUpdate() 
   {
       Vector3 deiredPosition = target.position + offset;
       Vector3 smoothedPosition = Vector3.Lerp(transform.position, deiredPosition, smoothSpeed * Time.deltaTime);
       transform.position = smoothedPosition;
    }
}
