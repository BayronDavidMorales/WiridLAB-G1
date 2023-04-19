using UnityEngine;

public class VRMouseCamera : MonoBehaviour
{
    public float sensitivity = 2.0f; // Sensibilidad del mouse
    public float smoothing = 2.0f; // Suavidad del movimiento
    public bool cameraEnabled = true; // Habilita o deshabilita el movimiento de cámara

    private Vector2 _mouseLook; // Vector de movimiento del mouse
    private Vector2 _smoothV; // Vector suavizado

    // Método Start se ejecuta al inicio del juego
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor del mouse en el centro de la pantalla
    }

    // Método Update se ejecuta una vez por frame
    void Update()
    {
        if (!cameraEnabled) return; // Si el movimiento de cámara está deshabilitado, sale del método

        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        _smoothV.x = Mathf.Lerp(_smoothV.x, mouseDelta.x, 1f / smoothing);
        _smoothV.y = Mathf.Lerp(_smoothV.y, mouseDelta.y, 1f / smoothing);
        _mouseLook += _smoothV;

        // Transforma la rotación horizontal en un vector local
        Vector3 localRotation = transform.localEulerAngles;
        localRotation.y += _smoothV.x;
        transform.localEulerAngles = localRotation;

        // Gira la cámara verticalmente
        transform.localRotation *= Quaternion.Euler(-_smoothV.y, 0, 0);
        _mouseLook.y = Mathf.Clamp(_mouseLook.y, -90f, 90f); // Limita la rotación vertical entre -90 y 90 grados
    }
}