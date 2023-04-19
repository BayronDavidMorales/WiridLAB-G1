using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRSphereNavigation : MonoBehaviour
{
    public Transform sphereParent; // Objeto padre que contiene las esferas
    private GameObject[] spheres; // Arreglo de las esferas a las que se puede mover la cámara
    private int currentSphereIndex = 0; // Índice de la esfera actual

    // Método Start se ejecuta al inicio del juego
    void Start()
    {

        // Busca todas las esferas dentro del objeto padre y las almacena en el arreglo "spheres"
        spheres = new GameObject[sphereParent.childCount];
        for (int i = 0; i < sphereParent.childCount; i++)
        {
            spheres[i] = sphereParent.GetChild(i).gameObject;
            spheres[i].SetActive(false); // Desactiva todas las esferas al inicio del juego
        }

        // Activa la primera esfera
        spheres[currentSphereIndex].SetActive(true);
    }

    // Método Update se ejecuta una vez por frame
    void Update()
    {
        // Cambia a una esfera aleatoria si se presiona la tecla izquierda o derecha
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            int newIndex;
            do
            {
                newIndex = Random.Range(0, spheres.Length); // Genera un índice aleatorio para las esferas
            } while (newIndex == currentSphereIndex); // Asegura que el índice aleatorio no sea igual al índice actual

            spheres[currentSphereIndex].SetActive(false); // Desactiva la esfera actual
            currentSphereIndex = newIndex; // Actualiza el índice de la esfera actual
            spheres[currentSphereIndex].SetActive(true); // Activa la esfera aleatoria
        }
    }
}
