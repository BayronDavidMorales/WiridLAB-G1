using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRKeyboardNavigation : MonoBehaviour
{
    public Transform[] spheres; // Arreglo de las esferas a las que se puede mover la c�mara
    public float moveSpeed = 0.1f; // Velocidad de movimiento de la c�mara

    // M�todo Start se ejecuta al inicio del juego
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor del mouse en el centro de la pantalla
    }

    // M�todo Update se ejecuta una vez por frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            int randomIndex = Random.Range(0, spheres.Length); // Escoge una esfera aleatoria
            Transform targetSphere = spheres[randomIndex]; // Obtiene la esfera correspondiente
            MoveToSphere(targetSphere); // Mueve la c�mara hacia la esfera correspondiente
        }
    }

    // Mueve la c�mara hacia una esfera espec�fica
    void MoveToSphere(Transform targetSphere)
    {
        // Calcula la posici�n final de la c�mara
        Vector3 finalPos = targetSphere.position;
        finalPos.y = transform.position.y;

        // Suaviza el movimiento de la c�mara hacia la esfera
        transform.position = Vector3.Lerp(transform.position, finalPos, moveSpeed);
    }
}
