using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UpdateManager : MonoBehaviour
{
    private static Action OnUpdate;
    private static Action OnFixedUpdate;
    private static Action OnLateUpdate;

    public static void SuscribeToUpdate(Action subscriber)
    {
        OnUpdate += subscriber;
    }
    
    public static void UnsuscribeToUpdate(Action subscriber)
    {
        OnUpdate -= subscriber;
    }
    
    public static void SuscribeToFixedUpdate(Action subscriber)
    {
        OnFixedUpdate += subscriber;
    }
    
    public static void UnsuscribeToFixedUpdate(Action subscriber)
    {
        OnFixedUpdate -= subscriber;
    }
    
    public static void SuscribeToLateUpdate(Action subscriber)
    {
        OnLateUpdate += subscriber;
    }
    
    public static void UnsuscribeToLateUpdate(Action subscriber)
    {
        OnLateUpdate -= subscriber;
    }

    private void Update()
    {
        if (OnUpdate != null)
        {
            OnUpdate();
        }
    }
    
    private void FixedUpdate()
    {
        if (OnFixedUpdate != null)
        {
            OnFixedUpdate();
        }
    }
    
    private void LateUpdate()
    {
        if (OnLateUpdate != null)
        {
            OnLateUpdate();
        }
    }
}
