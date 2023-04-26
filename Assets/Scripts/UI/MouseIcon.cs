using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseIcon : MonoBehaviour
{
    public Texture2D cursor_hand;
    public Vector2 handCursorHotSpot;

    public Texture2D cursor_handClose;
    public Vector2 handCloseCursorHotSpot;

    public Texture2D cursor_seleccion;
    public Vector2 onButtonSCursorHotSpot;

    public Texture2D cursor_zoomin;
    public Vector2 onClicZICursorHotSpot;

    public Texture2D cursor_zoomout;
    public Vector2 onButtonZOCursorHotSpot;

    bool p1=false;
    bool p2=false;
    bool p3=false;



    public void OnButtonCursorEnter(){
        Cursor.SetCursor(cursor_seleccion,onButtonSCursorHotSpot, CursorMode.Auto);
    }
    
    public void OnButtonCursorExit(){
        if (p1==false && p2==false && p3==false){
            Cursor.SetCursor(null,handCursorHotSpot, CursorMode.Auto);
        }else{
            if(p1 == true){
                Cursor.SetCursor(cursor_zoomout,onButtonZOCursorHotSpot, CursorMode.Auto);                
            }
            if(p2 == true){
                Cursor.SetCursor(cursor_seleccion,onButtonSCursorHotSpot, CursorMode.Auto);               
            }
            if(p3 == true){
                Cursor.SetCursor(cursor_hand,onButtonSCursorHotSpot, CursorMode.Auto);               
            }
        }
    }

    public void OnButtonCursorClic(int boton){
            switch(boton){
                case 1:
                    if(p1==false){
                        p1=true;
                        p2=false;
                        p3=false;
                        Cursor.SetCursor(cursor_zoomout,onButtonZOCursorHotSpot, CursorMode.Auto);
                    }else{
                        p1=false;
                        Cursor.SetCursor(null,handCursorHotSpot, CursorMode.Auto);
                    }                    
                    break;
            
                case 2:
                    if(p2==false){
                        p1=false;
                        p2=true;
                        p3=false;
                        Cursor.SetCursor(cursor_seleccion,onButtonSCursorHotSpot, CursorMode.Auto);
                    }else{
                        p2=false;
                        Cursor.SetCursor(null,handCursorHotSpot, CursorMode.Auto);
                    }                    
                    break;

                case 3:
                    if(p3==false){
                        p1=false;
                        p2=false;
                        p3=true;
                        Cursor.SetCursor(cursor_hand,onButtonSCursorHotSpot, CursorMode.Auto);
                    }else{
                        p3=false;
                        Cursor.SetCursor(null,handCursorHotSpot, CursorMode.Auto);
                    }  
                    break;

                default:
                    p1=false;
                    p2=false;
                    p3=false;
                    Cursor.SetCursor(null,handCursorHotSpot, CursorMode.Auto);
                    break;    
        }        
    }
}
