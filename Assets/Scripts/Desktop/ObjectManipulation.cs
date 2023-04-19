using UnityEngine;

public class ObjectManipulation : MonoBehaviour
{
    public LayerMask layerMask;
    public float rotationSpeed = 10f;
    public float zoomSpeed = 0.01f;

    private GameObject objectToManipulate;
    private bool objectSelected;
    private Vector3 originalScale;
    private Quaternion originalRotation;
    private bool cameraEnabled = true; // Habilita o deshabilita el movimiento de cámara
    public VRMouseCamera vrMouseCamera;

    public Material toonOutlineMaterial;
    private Material originalMaterial;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Lanza un rayo hacia adelante desde la posición de la cámara
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            // Si el rayo impacta un objeto en la capa especificada, lo selecciona
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, layerMask))
            {
                // Deshabilita el movimiento de cámara
                cameraEnabled = false;
                SelectObject(hitInfo.collider.gameObject);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            // Habilita el movimiento de cámara
            cameraEnabled = true;
            DeselectObject();
        }

        if (objectSelected)
        {
            Cursor.visible = true;
            // Rota el objeto con el ratón
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;
            objectToManipulate.transform.Rotate(Vector3.up, -mouseX, Space.World);
            objectToManipulate.transform.Rotate(Vector3.right, mouseY, Space.World);

            // Hace zoom en el objeto multiplicando el scroll de la rueda del ratón por la velocidad de zoom
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            objectToManipulate.transform.localScale += Vector3.one * scroll * zoomSpeed;

            // Limita la escala mínima a 0.1 para evitar escalas negativas
            objectToManipulate.transform.localScale = Vector3.Max(objectToManipulate.transform.localScale, Vector3.one * 0.1f);
        }
    }
    private void SelectObject(GameObject obj)
    {
        objectToManipulate = obj;
        objectSelected = true;

        // Guarda la escala y rotación original del objeto
        originalScale = objectToManipulate.transform.localScale;
        originalRotation = objectToManipulate.transform.rotation;

        // Desactiva el script VRMouseCamera
        vrMouseCamera.enabled = false;
    }




    private void DeselectObject()
    {
        try
        {
            objectToManipulate.transform.localScale = originalScale;
            objectToManipulate.transform.rotation = originalRotation;

            // Restaura el material original del objeto deseleccionado
            objectToManipulate.GetComponent<InteractableObject>().RestoreOriginalMaterial();
        }
        catch { }

        objectToManipulate = null;
        objectSelected = false;

        // Activa el script VRMouseCamera
        vrMouseCamera.enabled = true;
    }


}
