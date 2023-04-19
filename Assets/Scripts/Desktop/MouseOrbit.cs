using UnityEngine;
using System.Collections;

public class MouseOrbit : MonoBehaviour {
    public GameObject objectToManipulate;
    public GameObject firstPersonController;

    private bool objectSelected;
    private Vector3 lastMousePosition;

    void Update()
    {
        // Detecta si el jugador hace clic izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Realiza un raycast para detectar si el jugador está apuntando a un objeto en la escena
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == objectToManipulate)
                {
                    // Si el jugador está apuntando a un objeto, selecciona ese objeto y desactiva los movimientos del primer personaje
                    objectSelected = true;
                    lastMousePosition = Input.mousePosition;
                    firstPersonController.GetComponent<CharacterController>().enabled = false;
                }
            }
        }

        // Si el jugador ha seleccionado un objeto, mueve y rota el objeto según el movimiento del mouse
        if (objectSelected)
        {
            float deltaX = Input.mousePosition.x - lastMousePosition.x;
            float deltaY = Input.mousePosition.y - lastMousePosition.y;

            objectToManipulate.transform.Rotate(Vector3.up, deltaX, Space.World);
            objectToManipulate.transform.Rotate(Vector3.right, -deltaY, Space.World);

            lastMousePosition = Input.mousePosition;

            // Detecta si el jugador ha soltado el botón del mouse para dejar de manipular el objeto y reactiva los movimientos del primer personaje
            if (Input.GetMouseButtonUp(0))
            {
                objectSelected = false;
                firstPersonController.GetComponent<CharacterController>().enabled = true;
            }
        }
    }
}