using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sala : MonoBehaviour
{
    /*
        Este script se realiza mediante programación orientada a objetos:

        Cada sala contiene cierta cantidad de fotos y cierta cantidad de nodos, cada uno de esos elementos tiene sus 
        atributos y métodos.
    */

    public string nombreSala;
    public GameObject sala;
    public Material salaMat;
    public Foto[] fotosSala;
    public Nodo[] nodosSala;
    private bool vis=false;

    //Método ¿es visible?
    public bool getVisible(){
        return vis;
    }

    //Método hacer visible
    public void setVisibleSala(bool visible, string nombreFotoSala){
        if(visible==true){
            sala.SetActive(true);
            for(int i=0; i<fotosSala.Length;i++){
                if(fotosSala[i].nombreSalaFoto == nombreFotoSala){
                    fotosSala[i].setVisible(true, salaMat);
                    break;
                }
            }
            vis=true;
        }else{
            sala.SetActive(false);
            vis=false;
        }
    }

    //Método cambiar Posicion pines de los Nodos
    public void setPosisionNodoPines(int[][] position){
        for(int i=0; i<nodosSala.Length;i++){
            nodosSala[i].setPositionPin(position[i][0] , position[i][1] , position[i][2]);
        }
    }



}
