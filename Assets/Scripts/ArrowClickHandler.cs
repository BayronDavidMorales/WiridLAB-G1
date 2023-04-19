using UnityEngine;

public class ArrowClickHandler : MonoBehaviour
{
    public VRSphereNavigation sphereNavigation;

    // Método Update se ejecuta una vez por frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == this.gameObject)
                {
                    sphereNavigation.ChangeSphere();
                }
            }
        }
    }
}
