using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IdiomaManager : MonoBehaviour
{   
    public TMP_Dropdown dropdownInicio;
    public TMP_Dropdown dropdown;

    //Menu Inicial
    public TextMeshProUGUI tituloM_In;

    //Menu Configuracion
    public TextMeshProUGUI tituloM_Config;
    public TextMeshProUGUI idiomaM_Config;
    public TextMeshProUGUI sonidoM_Config;
    public GameObject t1;
    public GameObject t2;
    public Sprite t1ES, t1EN, t2ES, T2EN;


    void Start(){
        dropdown.onValueChanged.AddListener(delegate{
            cambiarIdioma(dropdown, dropdownInicio);
        });

        dropdownInicio.onValueChanged.AddListener(delegate{
            cambiarIdioma(dropdownInicio, dropdown);
        });
    }

    // Start is called before the first frame update
    public void cambiarIdioma(TMP_Dropdown dropdownEvent, TMP_Dropdown dropdownOther){
        Image t1Img;
        t1Img = t1.GetComponent<Image>();

        Image t2Img;
        t2Img = t2.GetComponent<Image>();
        
        if(dropdownEvent.value == 0){
            dropdownOther.value = 0;
            tituloM_In.text = "Recorrido virtual";
            tituloM_Config.text = "Configuración";
            idiomaM_Config.text = "IDIOMA";
            sonidoM_Config.text = "SONIDO";
            t1Img.sprite = t1ES;
            t2Img.sprite = t2ES;
        }

        if(dropdownEvent.value == 1){
            dropdownOther.value = 1;
            tituloM_In.text = "Virtual tour";
            tituloM_Config.text = "Settings";
            idiomaM_Config.text = "LANGUAGE";
            sonidoM_Config.text = "SOUND";
            t1Img.sprite = t1EN;
            t2Img.sprite = T2EN;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
