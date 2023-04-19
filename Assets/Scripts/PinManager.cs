using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PinManager : MonoBehaviour
{
    bool visible = false;
    bool isopenlat = false;
    int nodoaux;

    private Camera cam;
    private Ray rayito;
    public GameObject[] nodos;
    public GameObject[] pines;

    //Menú lateral
    public GameObject panelMenuLat;
    RectTransform rectTransformMenuLat;
    public TextMeshProUGUI tituloNodo;
    public TextMeshProUGUI descripcionNodo;

    void Start()
    {
        cam = Camera.main;
        rectTransformMenuLat = panelMenuLat.GetComponent<RectTransform>();
        for (int i = 0; i < nodos.Length; i++)
        {
            nodos[i].SetActive(false);
        }
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Vector3 wp = new Vector3( Input.mousePosition.x, Input.mousePosition.y, 0f );
            //Vector3 wpCal=  new Vector3( wp.x, Input.mousePosition.y, 0f );

            //Posición del mouse al hacer evento down
            /*Vector3 point = new Vector3();
            Event   currentEvent = Event.current;
            Vector2 mousePos = new Vector2();
            mousePos.x = Input.mousePosition.x;
            mousePos.y = cam.pixelHeight - Input.mousePosition.y;
            point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));*/

            rayito = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(rayito, out RaycastHit raycastHit))
            {
                //Cambio de estado del nodo presionado
                for (int i = 0; i < pines.Length; i++)
                {
                    Collider coll = pines[i].GetComponent<Collider>();
                    if (coll == raycastHit.collider)
                    {
                        cambiarEstadoNodo(i);
                        setpositionLatPanel(i);
                        break;
                    }
                }
            }

        }
    }

    public void cambiarEstadoNodo(int i)
    {
        if (visible == true && nodoaux == i)
        {
            visible = false;
            nodos[i].SetActive(false);
        }
        else if (visible == true && nodoaux != i)
        {
            for (int j = 0; j < nodos.Length; j++)
            {
                if (j == i)
                {
                    nodos[j].SetActive(true);
                    nodoaux = i;
                }
                else
                {
                    nodos[j].SetActive(false);
                }
            }
        }
        else
        {
            visible = true;
            nodoaux = i;
            nodos[i].SetActive(true);
        }
    }

    public void setpositionLatPanel(int i)
    {
        if (isopenlat == false || i != nodoaux)
        {
            rectTransformMenuLat.anchoredPosition = new Vector2(-720, 0);
            switch (i)
            {
                case 0: // Nodo Radio 72
                    tituloNodo.text = "Nodo Radio<br>No. 72";
                    descripcionNodo.text = "USE: VECTOR SIGNAL GENERATOR<br>OPERATIVE SYSTEM: Ubuntu 20.04.2 LTS<br>ARCHITECTURE: ARM<br>BOARD: RASPBERRY Pi Model B+ V1.3<br>MODULES:<br>   -TRENDNET ETHERNET ADAPTER RJ45 TO USB 2.0<br>   -Micro Sg90 Servomotor 9g<br>SERVICES:<br>   -Vector Signal Generator";
                    break;

                case 1: // Nodo Radio 88
                    tituloNodo.text = "Nodo Radio<br>No. 88";
                    descripcionNodo.text = "GATEWAY NI WSN";
                    break;

                case 2: // Nodo Radio 106
                    tituloNodo.text = "Nodo Radio<br>No. 106";
                    descripcionNodo.text = "NI-WSN";
                    break;

                case 3: // Nodo Radio 109
                    tituloNodo.text = "Nodo Radio<br>No. 109";
                    descripcionNodo.text = "OPERATIVE SYSTEM: Ubuntu 20.04.2 LTS<br>ARCHITECTURE: AMD64<br>DEVICE: ADVANTECH ARK 3520L<br>RADIO DEVICES:<br>   -WBX USRP<br>   -RTL<br>SERVICES:<br>   -GNU Radio v3.8 + UHD v3.15 + RTL + gr-bokehgui + Jupyter + Matlab<br>   -Python 3.6 + Jupyter";
                    break;

                case 4: //Nodo IoT 108
                    tituloNodo.text = "Nodo Iot<br>No. 108";
                    descripcionNodo.text = "USE: NRF24L0<br>OPERATIVE SYSTEM: Ubuntu, 20.04.2 LTS<br>ARCHITECTURE: ARM<br>BOARD: RASPBERRY Pi Model 3B V1.2<br>MICROCONTROLLER: ARDUINO NANO<br>SENSORS AND MODULES: NRF24L01 CONECTADO A ARDUINO NANO, MOSFET 5V, DHT11 – NANO<br>SERVICES: Node-Red + Arduino CLI + Grafana + InfluxDB 2.0, VNC + JUPYTER";
                    break;


                default:
                    tituloNodo.text = "Nodo<br>No encontrado";
                    descripcionNodo.text = "Verifique actualizar la página";
                    break;
            }
            isopenlat = true;
        }
        else
        {
            rectTransformMenuLat.anchoredPosition = new Vector2(-1105, 0);
            tituloNodo.text = "";
            descripcionNodo.text = "";
            isopenlat = false;
        }
    }


}
