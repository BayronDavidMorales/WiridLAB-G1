using UnityEngine;

public class VRMouseCamera : MonoBehaviour
{
    public float sensitivity = 2.0f; // Sensibilidad del mouse
    public float smoothing = 2.0f; // Suavidad del movimiento
    public bool cameraEnabled = true; // Habilita o deshabilita el movimiento de c�mara

    private Vector2 _mouseLook; // Vector de movimiento del mouse
    private Vector2 _smoothV; // Vector suavizado

    // M�todo Start se ejecuta al inicio del juego
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor del mouse en el centro de la pantalla
    }

    // M�todo Update se ejecuta una vez por frame
    void Update()
    {
        if (!cameraEnabled) return; // Si el movimiento de c�mara est� deshabilitado, sale del m�todo

        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        _smoothV.x = Mathf.Lerp(_smoothV.x, mouseDelta.x, 1f / smoothing);
        _smoothV.y = Mathf.Lerp(_smoothV.y, mouseDelta.y, 1f / smoothing);
        _mouseLook += _smoothV;

        // Transforma la rotaci�n horizontal en un vector local
        Vector3 localRotation = transform.localEulerAngles;
        localRotation.y += _smoothV.x;
        transform.localEulerAngles = localRotation;

        // Gira la c�mara verticalmente
        transform.localRotation *= Quaternion.Euler(-_smoothV.y, 0, 0);
        _mouseLook.y = Mathf.Clamp(_mouseLook.y, -90f, 90f); // Limita la rotaci�n vertical entre -90 y 90 grados
    }
}