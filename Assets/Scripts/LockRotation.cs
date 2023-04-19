using UnityEngine;

public class LockRotation : MonoBehaviour
{
    private float initialRotationY;
    private float initialRotationZ;

    void Start()
    {
        initialRotationY = transform.eulerAngles.y;
        initialRotationZ = transform.eulerAngles.z;
    }

    void LateUpdate()
    {
        // Mant�n la rotaci�n original en los ejes Y y Z
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, initialRotationY, initialRotationZ);
    }
}
