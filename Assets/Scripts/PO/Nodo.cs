using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodo : MonoBehaviour
{
    //Variables
    public string nombreES;
    public string nombreEN;
    public string descripcionES;
    public string descripcionEN;
    public GameObject pin;
    public GameObject nodo;
    private bool vis = false;

    void Start(){
        setVisible(false);
    }

    //Método ¿es visible?
    public bool getVisible(){
        return vis;
    }
    
    //Método hacer visible
    public void setVisible(bool visible){
        if(visible == true){
            nodo.SetActive(true);
            vis = true;
        }else{
            nodo.SetActive(false);
            vis = false;
        }
    }

    //Método escalar
    public void escalarNodo(float dimensión){

    }

    //Método rotar
    public void rotarNodo(float angulo){
        
    }

    //Cambiar posición pin
    public void setPositionPin(float x, float y, float z){
        pin.transform.position= new Vector3(x,y,z);
    }
}
