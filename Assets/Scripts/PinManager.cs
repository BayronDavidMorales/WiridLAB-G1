using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinManager : MonoBehaviour
{
    bool visible=false;
    private Camera cam;
    public GameObject nodo;
    public GameObject pin;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
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

}
