using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PanelManager : MonoBehaviour
{
    public GameObject panelInicio;
    public GameObject panelConfiguracion;
    public GameObject panelMenuInf;
    public GameObject panelMenuLat;
    RectTransform rectTransformMenuLat;

    public GameObject miniMap;
    public GameObject FPSController;

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
        else if (Input.GetKeyUp(KeyCode.Escape))
        {
            DisableFPSController();
        }
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

    public void EnableFPSController()
    {
        FPSController.GetComponent<VRMouseCamera>().enabled = true;
        FPSIsActive = true;
        activeMinimap();
    }

    public void DisableFPSController()
    {
        FPSIsActive = false;
        FPSController.GetComponent<VRMouseCamera>().enabled = false;
    }

    public void activeMinimap()
    {
        miniMap.SetActive(true);
        FPSController.GetComponent<MiniMapComponent>().enabled = true;

        // Obtiene todos los objetos con la capa "ObjectToManipulate"
        GameObject[] objectsToManipulate = GameObject.FindObjectsOfType<GameObject>().Where(obj => obj.layer == LayerMask.NameToLayer("ObjectToManipulate")).ToArray();

        // Recorre los objetos y activa el componente "MiniMapComponent"
        foreach (GameObject obj in objectsToManipulate)
        {
            obj.GetComponent<MiniMapComponent>().enabled = true;
        }
    }
}
