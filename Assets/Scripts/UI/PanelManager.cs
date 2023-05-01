using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class PanelManager : MonoBehaviour
{
    public GameObject panelInicio;
    public GameObject panelConfiguracion;
    public GameObject panelMenuInf;
    public GameObject T1;
    public GameObject T2;
    public Canvas canvasInformacionNodo;
    public Canvas canvasPrincipal;
    

    bool tuto=true;

    void Start(){
        panelConfiguracion.SetActive(false);
        canvasInformacionNodo.enabled = false;
    }


    //Canvas Inicial
    public void openInicio(){
        panelConfiguracion.SetActive(false);
        panelInicio.SetActive(true);
    }

    public void closeInicio(){
        panelInicio.SetActive(false);
    }

    public void openConfig(){
        panelConfiguracion.SetActive(true);
    }

    public void closeConfig(){
        panelConfiguracion.SetActive(false);
    }

    public void openT1(bool helped){
        if(tuto == true || helped == true){
            T1.SetActive(true);
            tuto=false;
        }
    }

    //Tutorial
    public void openT2(){
        T2.SetActive(true);
    }

    public void closeT1(){
        T1.SetActive(false);
    }

    public void closeT2(){
        T2.SetActive(false);
    }

    //Canvas información de nodo
    public void openCanvasInfo(){
        canvasInformacionNodo.enabled = true;
    }

    public void closeCanvasInfo(){
        canvasInformacionNodo.enabled = false;
    }

    //Canvas principal
    public void openCanvasPrin(){
        canvasPrincipal.enabled = true;
    }

    public void closeCanvasPrin(){
        canvasPrincipal.enabled = false;
    }
}
