using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PinManager : MonoBehaviour
{
    bool visible=false;
    bool isopenlat=false;

    private Camera cam;
    public GameObject nodo;
    public GameObject pin;
    public GameObject panelMenuLat;
    RectTransform rectTransformMenuLat;
    public TextMeshProUGUI tituloNodo;
    public TextMeshProUGUI descripcionNodo;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rectTransformMenuLat = panelMenuLat.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetMouseButtonDown(0)){
            //Vector3 wp = new Vector3( Input.mousePosition.x, Input.mousePosition.y, 0f );
            //Vector3 wpCal=  new Vector3( wp.x, Input.mousePosition.y, 0f );

            Vector3 point = new Vector3();
            Event   currentEvent = Event.current;
            Vector2 mousePos = new Vector2();

            // Get the mouse position from Event
            mousePos.x = Input.mousePosition.x;
            mousePos.y = cam.pixelHeight - Input.mousePosition.y;

            point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

            CapsuleCollider2D coll = pin.GetComponent<CapsuleCollider2D>();

            if(coll.OverlapPoint(point)){
                cambiarEstadoNodo(nodo);
                setpositionLatPanel();
                
            }
        }
    }
    public void cambiarEstadoNodo(GameObject nodo){
        if(visible == true){
            visible=false;
            nodo.SetActive(false);
        }else{
            visible=true;
            nodo.SetActive(true);
        }
    }

    public void setpositionLatPanel(){
        if(isopenlat == false){
            rectTransformMenuLat.anchoredPosition = new Vector2(-720,0);
            tituloNodo.text="Nodo Iot            No. 108";
            descripcionNodo.text="USE: NRF24L0;                                                        OPERATIVE SYSTEM: Ubuntu, 20.04.2 LTS;      ARCHITECTURE: ARM;                                                  BOARD: RASPBERRY Pi Model 3B V1.2;                                                                       MICROCONTROLLER: ARDUINO NANO;                                 SENSORS AND MODULES: NRF24L01 CONECTADO A ARDUINO NANO, MOSFET 5V, DHT11 – NANO;   SERVICES: Node-Red + Arduino CLI + Grafana + InfluxDB 2.0, VNC + JUPYTER";
            isopenlat = true;
        }else{
            rectTransformMenuLat.anchoredPosition = new Vector2(-1105, 0);
            tituloNodo.text="";
            descripcionNodo.text="";
            isopenlat = false;
        }
    }
    

}
