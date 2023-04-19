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
    public GameObject T1;
    public GameObject T2;
    RectTransform rectTransformMenuLat;

    public GameObject miniMap;
    public GameObject FPSController;

    bool isopenlat=false;
    bool FPSIsActive = false;
    bool tuto = true;

    void Start(){
        panelConfiguracion.SetActive(false);
        rectTransformMenuLat = panelMenuLat.GetComponent<RectTransform>();
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (FPSIsActive == true)
            {
                DisableFPSController();
            }
            else
            {
                EnableFPSController();
            }
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
        FPSController.GetComponent<VRSphereNavigation>().enabled = true;
        FPSController.GetComponent<ObjectManipulation>().enabled = true;
        FPSIsActive = true;
        activeMinimap();

        // Bloquea y oculta el cursor
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

    }

    public void DisableFPSController()
    {
        FPSIsActive = false;
        FPSController.GetComponent<VRMouseCamera>().enabled = false;
        FPSController.GetComponent<VRSphereNavigation>().enabled = false;
        FPSController.GetComponent<ObjectManipulation>().enabled = false;

        // Desbloquea y muestra el cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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

            // Imprime el nombre del objeto en la consola de Unity
            Debug.Log("Object: " + obj.name);

            try
            {
                obj.GetComponent<MiniMapComponent>().enabled = true;
            }
            catch { }

        }
    }

    public void openT1()
    {
        if (tuto == true)
        {
            T1.SetActive(true);
            tuto = false;
        }
    }

    public void openT2()
    {
        T2.SetActive(true);
    }

    public void closeT1()
    {
        T1.SetActive(false);
    }

    public void closeT2()
    {
        T2.SetActive(false);
    }
}
