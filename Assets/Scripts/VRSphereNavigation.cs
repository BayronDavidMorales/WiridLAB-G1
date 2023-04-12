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
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor del mouse en el centro de la pantalla

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
        // Cambia a la esfera siguiente si se presiona la tecla izquierda
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spheres[currentSphereIndex].SetActive(false); // Desactiva la esfera actual
            currentSphereIndex--; // Cambia al índice de la esfera siguiente
            if (currentSphereIndex < 0) currentSphereIndex = spheres.Length - 1; // Si se llega al final del arreglo, regresa al inicio
            spheres[currentSphereIndex].SetActive(true); // Activa la esfera siguiente
        }

        // Cambia a la esfera anterior si se presiona la tecla derecha
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            spheres[currentSphereIndex].SetActive(false); // Desactiva la esfera actual
            currentSphereIndex++; // Cambia al índice de la esfera anterior
            if (currentSphereIndex >= spheres.Length) currentSphereIndex = 0; // Si se llega al final del arreglo, regresa al inicio
            spheres[currentSphereIndex].SetActive(true); // Activa la esfera anterior
        }
    }
}
