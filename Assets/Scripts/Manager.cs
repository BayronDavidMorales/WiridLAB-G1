using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class Manager : MonoBehaviour
{  

    Sala[] salasManager;
    PanelManager panelManager;
    int[][] posicionesPines;
    private Ray rayito;
    private CameraOrbit cameraFocusNodo;

    public TextMeshProUGUI tituloNodo;
    public TextMeshProUGUI descripcionNodo;
    public TMP_Dropdown idiomaDropdown;
    public Camera cam;
    public Camera camInfo;
    public GameObject camInfoScript;

   

    // Start is called before the first frame update
    void Start()
    {
        //Instanciar script
        panelManager = GetComponent<PanelManager>();
        cameraFocusNodo = camInfoScript.GetComponent<CameraOrbit>();

        //Lista de salas
        salasManager= new Sala[4];
        salasManager[0]=GameObject.Find("Sala 1").GetComponent<Sala>();
        salasManager[1]=GameObject.Find("Sala 2").GetComponent<Sala>();
        salasManager[2]=GameObject.Find("Sala 3").GetComponent<Sala>();
        salasManager[3]=GameObject.Find("Terraza").GetComponent<Sala>();

        //Desactivar y activar salas
        salasManager[1].setVisibleSala(false,null);
        salasManager[2].setVisibleSala(false,null);
        salasManager[3].setVisibleSala(false,null);
        salasManager[0].setVisibleSala(true,"Foto1SalaPrin");


    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetMouseButtonDown(0)){
            presionarPin();
            presionarPinPiso();
        }
    }

    //Función cambiarFoto
    public void cambiarFoto(string nombreFoto){
        for(int i=0 ; i<salasManager.Length ; i++){
            if(salasManager[i].getVisible() == true){
                salasManager[i].setVisibleSala(true, nombreFoto);
                break;
            }
        }
    }

    //Cambiar sala
    public void cambiarSala(string salaNombre, string nombreFoto){
        
        //Desactivar otras salas
        for(int i=0 ; i<salasManager.Length ; i++){
            if(salasManager[i].getVisible() == true){
                //Desactivar nodos
                for(int j=0;j<salasManager[i].nodosSala.Length;j++){
                    salasManager[i].nodosSala[j].setVisible(false);
                }
                salasManager[i].setVisibleSala(false, null);
            }
        }

        //Activar sala
        for(int i=0 ; i<salasManager.Length ; i++){
            if(salasManager[i].nombreSala == salaNombre){
                salasManager[i].setVisibleSala(true, nombreFoto);
            }
        }

    }

    //Al presionar un pin de nodo
    public void presionarPin(){
        rayito= cam.ScreenPointToRay(Input.mousePosition);
        for(int i=0 ; i<salasManager.Length ; i++){

            if(salasManager[i].getVisible() == true){
                if(Physics.Raycast(rayito, out RaycastHit raycastHit)){
                    for(int j=0; j<salasManager[i].nodosSala.Length;j++){
                        //Aparición nodo
                        if(raycastHit.collider == salasManager[i].nodosSala[j].pin.GetComponent<Collider>()){
                            if(idiomaDropdown.value == 0){
                                setTexto(salasManager[i].nodosSala[j].nombreES , salasManager[i].nodosSala[j].descripcionES);
                            }else{
                                setTexto(salasManager[i].nodosSala[j].nombreEN , salasManager[i].nodosSala[j].descripcionEN);
                            }
                            panelManager.closeCanvasPrin();
                            panelManager.openCanvasInfo();
                            cameraFocusNodo.setNodoFocus(salasManager[i].nodosSala[j].nodo);
                            camInfo.enabled = true;
                            salasManager[i].nodosSala[j].setVisible(true);
                            break;
                        }                           
                    }
                }
            }

        }
    }


    //Al cerrar panel
    public void ocultarNodo(){
        for(int i=0 ; i<salasManager.Length ; i++){
            if(salasManager[i].getVisible() == true){
                    for(int j=0; j<salasManager[i].nodosSala.Length;j++){
                        salasManager[i].nodosSala[j].setVisible(false);
                    }
            }
        }
    }
    //Al presionar un pin de cambio de foto o cambio de sala
    public void presionarPinPiso(){ 
        rayito= cam.ScreenPointToRay(Input.mousePosition);
        for(int i=0 ; i<salasManager.Length ; i++){
            if(salasManager[i].getVisible() == true){
                if(Physics.Raycast(rayito, out RaycastHit raycastHit)){

                    for(int j=0 ; j<salasManager[i].fotosSala.Length ; j++){
                        
                        for(int k=0; k<salasManager[i].fotosSala[j].spritesDeSala.Length ; k++){
                            //Cambio foto en sala
                            if(raycastHit.collider == salasManager[i].fotosSala[j].spritesDeSala[k].GetComponent<Collider>()){
                                cambiarFoto(salasManager[i].fotosSala[j].cambioFotoSalaActual[k]);
                                break;
                            }
                        }

                        for(int k=0; k<salasManager[i].fotosSala[j].spritesCambioSala.Length ; k++){
                            //Cambio de sala
                            if(raycastHit.collider == salasManager[i].fotosSala[j].spritesCambioSala[k].GetComponent<Collider>()){
                                cambiarSala(salasManager[i].fotosSala[j].nombreSalaDestino[k] , salasManager[i].fotosSala[j].nombrefotoSalaDestino[k]);
                                break;
                            }   
                        }                      
                                                 
                    }

                }
            }

        }
    }

    //Actualizar información panel nodos
    public  void setTexto(string nombreNodo, string descripcion){
        tituloNodo.text = nombreNodo;
        descripcionNodo.text = descripcion;
    }

}
