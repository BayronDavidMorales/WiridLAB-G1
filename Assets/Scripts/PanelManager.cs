using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject panelInicio;
    public GameObject panelConfiguracion;
    public GameObject panelMenuInf;
    public GameObject panelMenuLat;
    RectTransform rectTransformMenuLat;

    bool isopenlat=false;

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


}
