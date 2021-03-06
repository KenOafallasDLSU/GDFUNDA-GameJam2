using UnityEngine;
using System.Collections;

public class ShowCursor : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.ForceSoftware;
    public Vector2 hotSpot = Vector2.zero;
    void Start() 
    {
        Cursor.visible = true;
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
    
    // void OnMouseEnter()
    // {
    //     Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    // }

    // void OnMouseExit()
    // {
    //     Cursor.SetCursor(null, Vector2.zero, cursorMode);
    // }
}