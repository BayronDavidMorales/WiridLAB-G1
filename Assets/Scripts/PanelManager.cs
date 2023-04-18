using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject panelInicio;
    public GameObject panelConfiguracion;
    public GameObject panelMenuInf;
    public GameObject panelMenuLat;
    public GameObject T1;
    public GameObject T2;
    RectTransform rectTransformMenuLat;

    bool isopenlat=false;
    bool tuto=true;

    void Start(){
        panelConfiguracion.SetActive(false);
        rectTransformMenuLat = panelMenuLat.GetComponent<RectTransform>();
    }

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

    public void setpositionLatPanel(){
        if(isopenlat == false){
            rectTransformMenuLat.anchoredPosition = new Vector2(-720,0);
            isopenlat = true;
        }else{
            rectTransformMenuLat.anchoredPosition = new Vector2(-1105, 0);
            isopenlat = false;
        }
    }

    public void openT1(){
        if(tuto == true){
            T1.SetActive(true);
            tuto=false;
        }
    }

    public void openT2(){
        T2.SetActive(true);
    }

    public void closeT1(){
        T1.SetActive(false);
    }

    public void closeT2(){
        T2.SetActive(false);
    }
}
