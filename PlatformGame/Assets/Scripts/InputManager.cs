using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public static float GetAxis(string axisName)
    {
        return Input.GetAxis(axisName);
    }
    
    public static bool JumpPressed()
    {
        return Input.GetButtonDown("Jump");
    }

    public static float GetMouseX()
    {
        return Input.GetAxis("Mouse X");
    }
    
    public static float GetMouseY()
    {
        return Input.GetAxis("Mouse Y");
    }
    
}
