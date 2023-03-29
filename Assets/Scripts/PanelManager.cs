using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class PanelManager : MonoBehaviour
{
    public GameObject panelInicio;
    public GameObject panelConfiguracion;
    public GameObject panelMenuInf;
    public GameObject panelMenuLat;
    public GameObject miniMap;
    public GameObject FPSController;

    RectTransform rectTransformMenuLat;

    bool isopenlat=false;
    bool FPSIsActive = false;

    void Start(){
        panelConfiguracion.SetActive(false);
        rectTransformMenuLat = panelMenuLat.GetComponent<RectTransform>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && FPSIsActive == true)
        {
            DisableFPSController();
        }
    }

    public void openInicio(){
        miniMap.SetActive(false);
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

    public void EnableFPSController()
    {
        FPSIsActive = true;
        FPSController.GetComponent<FirstPersonController>().enabled = true;
        miniMap.SetActive(true);
    }

    public void DisableFPSController()
    {
        FPSIsActive = false;
        FPSController.GetComponent<FirstPersonController>().enabled = false;
    }


}
