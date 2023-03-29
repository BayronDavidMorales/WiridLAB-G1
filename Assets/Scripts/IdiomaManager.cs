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
        
        if(dropdownEvent.value == 0){
            dropdownOther.value = 0;
            tituloM_In.text = "Recorrido virtual";
            tituloM_Config.text = "Configuración";
            idiomaM_Config.text = "IDIOMA";
            sonidoM_Config.text = "SONIDO";
        }

        if(dropdownEvent.value == 1){
            dropdownOther.value = 1;
            tituloM_In.text = "Virtual tour";
            tituloM_Config.text = "Settings";
            idiomaM_Config.text = "IDIOM";
            sonidoM_Config.text = "SOUND";
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
