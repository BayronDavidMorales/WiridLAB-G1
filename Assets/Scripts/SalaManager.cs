using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SalaManager : MonoBehaviour
{
    bool visible=false;
    bool isopenlat=false;
    int nodoaux;
    
    private Camera cam;
    private Ray rayito;
    public GameObject[] salas;
    public GameObject[] spritesCambioSala;


    void Start()
    {
        cam = Camera.main;
        for(int i=1; i<salas.Length;i++){
            salas[i].SetActive(false);  
        }
    }


    void Update(){
        if(Input.GetMouseButtonDown(0)){
            rayito = cam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(rayito, out RaycastHit raycastHit)){
                
                //Cambio de sala
                for(int i=0; i<spritesCambioSala.Length;i++){
                    if(raycastHit.collider == spritesCambioSala[i].GetComponent<Collider>()){
                        Debug.Log("Entro");
                        cambiarSala(i);
                        break;
                    }
                }
            }
      
        }
    }

    public void cambiarSala(int j){
        for(int i=0; i<salas.Length;i++){
            if(j == i){
                salas[i].SetActive(true);     
            }else{
                salas[i].SetActive(false);  
            }
        }
    }

   
}
