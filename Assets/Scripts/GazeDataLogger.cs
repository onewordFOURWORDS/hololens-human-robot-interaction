using System.Collections;
using System.Collections.Generic;
using System;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;

public class GazeDataLogger : MonoBehaviour  
{
    public GameObject myCamera;
    private void Awake()
    {
        StartCoroutine(GazeLogger());
        Debug.Log(myCamera.transform.position.x);
        Debug.Log(myCamera.transform.position.y);
        Debug.Log(myCamera.transform.position.z);
        string eyeTrackingInfo = string.Format("IsEyeCalibrationValid: {0}, IsEyeTrackingEnabled: {1}, IsEyeTrackingEnabledAndValid: {2}," +
            "IsEyeTrackingDataValid: {3}", CoreServices.InputSystem.EyeGazeProvider.IsEyeCalibrationValid, CoreServices.InputSystem.EyeGazeProvider.IsEyeTrackingEnabled,
            CoreServices.InputSystem.EyeGazeProvider.IsEyeTrackingEnabledAndValid, CoreServices.InputSystem.EyeGazeProvider.IsEyeTrackingDataValid);
        Debug.Log(eyeTrackingInfo);
    }

    private void Start() 
    {
        string eyeTrackingInfo = string.Format("IsEyeCalibrationValid: {0}, IsEyeTrackingEnabled: {1}, IsEyeTrackingEnabledAndValid: {2}," +
           "IsEyeTrackingDataValid: {3}", CoreServices.InputSystem.EyeGazeProvider.IsEyeCalibrationValid, CoreServices.InputSystem.EyeGazeProvider.IsEyeTrackingEnabled,
           CoreServices.InputSystem.EyeGazeProvider.IsEyeTrackingEnabledAndValid, CoreServices.InputSystem.EyeGazeProvider.IsEyeTrackingDataValid);
        Debug.Log(eyeTrackingInfo);
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
