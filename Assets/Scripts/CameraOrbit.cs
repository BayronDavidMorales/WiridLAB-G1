using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public GameObject nodo;
    public Camera cameraMain;
    public Camera cameraOrbit;
    //public Transform follow;
    public float[] distance;
    [SerializeField] private Canvas panelInformacion;

    public float angle;
    private float damping = 3.0f;
    private Quaternion rotation;


    private void LateUpdate(){
        if(nodo.activeSelf && panelInformacion.enabled == true){
            transform.position = nodo.transform.position + new Vector3 (distance[0],distance[1],distance[2]); //3, 0 , 1.5
            rotation = Quaternion.Euler (0,angle,0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);     
        }else if(panelInformacion.enabled == false){
            transform.position = new Vector3 (0,0,cameraMain.transform.position.z);
            rotation = Quaternion.Euler (0.0f,0.0f,0.0f);
            transform.rotation = rotation;
            cameraOrbit.enabled = false;
            cameraMain.enabled = true;
        }
    }

    public void setNodoFocus(GameObject nodoFocus){
        nodo = nodoFocus;
    }

    public void setDistanceFocus(float[] distanceFocus){
        distance = distanceFocus;
    }

    public void setAngle(float angleN){
        angle = angleN;
    }
}
