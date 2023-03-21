using System.Collections;
using System.Collections.Generic;
using System;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;

public class GazeDataLogger : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(GazeLogger());
    }
    
    IEnumerator GazeLogger()
    {
        while (true)
        {
            //Grab Gaze Info

            Vector3 GazeOrigin = CoreServices.InputSystem.GazeProvider.GazeOrigin;
            Vector3 GazeHit = CoreServices.InputSystem.GazeProvider.HitPosition;
            GameObject GazeObject = CoreServices.InputSystem.GazeProvider.GazeTarget;
            Vector3 GazeLook = CoreServices.InputSystem.GazeProvider.GazeDirection;

            //Format Output
            string logInfo = String.Format("Gaze Origin: {0:0.000}, Gaze Hit: {1:0.000}, Gaze Object: {2}, " +
                                            "Gaze Look: {3:0.000}", GazeOrigin, GazeHit, GazeObject, GazeLook);
            //Log to Console
            Debug.Log(logInfo);

            yield return new WaitForSeconds(.1f);
        }

    }
}
