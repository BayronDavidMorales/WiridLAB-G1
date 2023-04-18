using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audManager;

    public AudioClip mAmbiente;
    public AudioClip m1;
    public AudioClip m3;
    public AudioClip m4;
    public AudioClip m5;
    public AudioClip m6;
    public AudioClip mClic;
    public Slider mainSlider;

    AudioClip[] musicas;
    int[] listaM;

    IEnumerator Start()
    {
        musicas=new AudioClip[5];
        musicas[0]=m1;
        musicas[1]=m3;
        musicas[2]=m4;
        musicas[3]=m5;
        musicas[4]=m6;
        

        listaM=new int[musicas.Length];
        int[] orden= new int[musicas.Length];


        for (int i=0; i<musicas.Length;i++){
            bool t=false;
            do{
                int aux=Random.Range(0,orden.Length);
                if(orden[aux] == 0){
                    orden[aux]=aux+1;
                    t=true;
                    listaM[i]=aux;
                }
            }while(t!=true);
        }

        audManager = GetComponent<AudioSource>();
        for(int i=0;i<listaM.Length;i++){
            audManager.clip = musicas[listaM[i]];
            audManager.Play();
            yield return new WaitForSeconds(audManager.clip.length);
        }

    }

    public void cambiarVolumen(){
        audManager.volume=mainSlider.value;
    }

}
