using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseIcon : MonoBehaviour
{
    public Texture2D cursor_normal;
    public Vector2 normalCursorHotSpot;

    public Texture2D cursor_clic;
    public Vector2 onButtonCursorHotSpot;

    bool pressed = false;

    public void OnButtonCursorEnter(){
        Cursor.SetCursor(cursor_clic,onButtonCursorHotSpot, CursorMode.Auto);
    }
    
    public void OnButtonCursorExit(){
        Cursor.SetCursor(cursor_normal,normalCursorHotSpot, CursorMode.Auto);
    }

    public void OnButtonCursorClic(){
        if(pressed == false){
            pressed = true;
            Cursor.SetCursor(cursor_clic,onButtonCursorHotSpot, CursorMode.Auto);
        }else{
            pressed = false;
            Cursor.SetCursor(cursor_normal,normalCursorHotSpot, CursorMode.Auto);
        }
        
    }
}
