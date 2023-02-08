using System.Collections;
using System.Collections.Generic;
using System;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;

public class GazeDataLogger : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        LogCurrentGazeTarget();
        LogGazeDirectionOrigin();
        LogHitPosition();
    }

    void LogCurrentGazeTarget()
    {
        if (CoreServices.InputSystem.GazeProvider.GazeTarget)
        {
            Debug.Log("User gaze is currently over game object: " + CoreServices.InputSystem.GazeProvider.GazeTarget);
        }
        else
        {
            Debug.Log("This is not working");
        }
    }

    void LogGazeDirectionOrigin()
    {
        Debug.Log("Gaze is looking in direction: " + CoreServices.InputSystem.GazeProvider.GazeDirection);
        
        Debug.Log("Gaze Origin is: " + CoreServices.InputSystem.GazeProvider.GazeOrigin);
    }

    void LogHitPosition()
    {
        Debug.Log("Gaze hit an object at: " + CoreServices.InputSystem.GazeProvider.HitPosition);
    }
    
    
}
