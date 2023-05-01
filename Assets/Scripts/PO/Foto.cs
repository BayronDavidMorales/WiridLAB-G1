using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foto : MonoBehaviour
{
    //Variables
    public string nombreSalaFoto;
    public Texture fotoDeLaSala;

    public GameObject[] spritesDeSala;
    public string[] cambioFotoSalaActual;

    public GameObject[] spritesCambioSala;
    public string[] nombreSalaDestino;
    public string[] nombrefotoSalaDestino;

    private bool vis=false;


    //Método ¿es visible?
    public bool getVisible(){
        return vis;
    }

    //Método hacer visible
    public void setVisible(bool visible, Material sala){
        if(visible==true){
            for(int i=0; i<spritesCambioSala.Length;i++){                    
                spritesCambioSala[i].SetActive(true);
            }
            for(int i=0; i<spritesDeSala.Length;i++){                    
                spritesDeSala[i].SetActive(true);
            }
            sala.SetTexture(nombreSalaFoto, fotoDeLaSala);
            vis=true;
        }else{
            for(int i=0; i<spritesCambioSala.Length;i++){                    
                spritesCambioSala[i].SetActive(false);
            }
            for(int i=0; i<spritesDeSala.Length;i++){                    
                spritesDeSala[i].SetActive(false);
            }
            sala.SetTexture(null, null);
            vis=false;
        }
    }

}
