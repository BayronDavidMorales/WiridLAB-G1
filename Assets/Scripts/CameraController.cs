using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{   
    //Sensitivity of the mouse
    private float rotateSpeed = 400.0f;

    //Zoom in/out variables
    private float zoomSpeed = 200.0f;
    private float zoomAmount = 0.0f;

    //Panel inicio
    [SerializeField] private GameObject panelInicio;
    [SerializeField] private GameObject t1;
    [SerializeField] private GameObject t2;
    [SerializeField] private GameObject panelConfiguracion;
    [SerializeField] private Camera cameraMain;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(panelInicio.activeSelf == false && t1.activeSelf == false && t2.activeSelf == false && panelConfiguracion.activeSelf == false && cameraMain.isActiveAndEnabled == true){
            if(Input.GetMouseButton(0)){
                //Rotate our camera according to the mouse
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x+Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed,  transform.localEulerAngles.y-Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed , 0 );
            }

            if(Input.GetMouseButton(1) || Input.GetMouseButton(2) ){
                //Move camera forward/back
                zoomAmount = Mathf.Clamp(zoomAmount + Input.GetAxis("Mouse Y") * Time.deltaTime * zoomSpeed, -4.0f, 4.0f);
                Camera.main.transform.localPosition = new Vector3(0,0, zoomAmount);
            }
        }
        
    }
}
