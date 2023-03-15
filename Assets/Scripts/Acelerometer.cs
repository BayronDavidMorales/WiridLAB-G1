using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Acelerometer : MonoBehaviour
{
    float speed = 40.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 dir= Vector3.zero;
        dir.x= -Input.acceleration.y;
        dir.z= Input.acceleration.x;

        if(dir.sqrMagnitude > 1){
            dir.Normalize();
        }

        dir *= Time.deltaTime;

        transform.Translate (dir * speed);
    }
}
