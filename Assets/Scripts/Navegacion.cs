using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navegacion : MonoBehaviour
{
    // Start is called before the first frame update
    public void Load(int sceneNumber){
        Debug.Log("Clicked!");
        SceneManager.LoadScene(sceneNumber);
    }
}
