using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBeheviour
{
    public static void ShowMouseAndCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    
    public static void HideMouseAndCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
