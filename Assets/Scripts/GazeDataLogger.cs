using System.Collections;
using System.Collections.Generic;
using System;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;

public class GazeDataLogger : MonoBehaviour
{
    public float dataLogFreq = 0.1f;
    private float _timeElapsed;
    
   private void Awake()
    {
        //StartCoroutine(GazeLogger());
        FileWriter.createDirectory();
        FileWriter.createFile();
    }

    private void Start()
    {
        bool trackingEnabled = CoreServices.InputSystem.EyeGazeProvider.IsEyeTrackingEnabled;
        bool? calibrationValid = CoreServices.InputSystem.EyeGazeProvider.IsEyeCalibrationValid;
        bool enabledAndValid = CoreServices.InputSystem.EyeGazeProvider.IsEyeTrackingEnabledAndValid;
        bool dataValid = CoreServices.InputSystem.EyeGazeProvider.IsEyeTrackingDataValid;
        
        string logInfo = String.Format("Tracking Enabled: {0}   Calibration Valid: {1}  Enabled and Valid: {2}  " + 
                                       "Valid Data: {3}", trackingEnabled, calibrationValid, enabledAndValid, dataValid);
        FileWriter.logData(logInfo);
    }

    public void Update()
    {
        Vector3 gazeOrigin = CoreServices.InputSystem.GazeProvider.GazeOrigin;
        Vector3 gazeHit = CoreServices.InputSystem.GazeProvider.HitPosition;
        GameObject gazeObject = CoreServices.InputSystem.GazeProvider.GazeTarget;
        Vector3 gazeLook = CoreServices.InputSystem.GazeProvider.GazeDirection;

        _timeElapsed += Time.deltaTime;

        if (_timeElapsed > dataLogFreq)
        {
            string logInfo = String.Format(DateTime.Now + "    Gaze Origin: {0:0.000}  Gaze Hit: {1:0.000} Gaze Object: {2}    " +
                                           "Gaze Look: {3:0.000}", gazeOrigin, gazeHit, gazeObject, gazeLook);

            FileWriter.logData(logInfo);

            _timeElapsed = 0;
        }
    }

    /*IEnumerator GazeLogger()
    {
        while (true)
        {
            //Grab Gaze Info
            Vector3 gazeOrigin = CoreServices.InputSystem.GazeProvider.GazeOrigin;
            Vector3 gazeHit = CoreServices.InputSystem.GazeProvider.HitPosition;
            GameObject gazeObject = CoreServices.InputSystem.GazeProvider.GazeTarget;
            Vector3 gazeLook = CoreServices.InputSystem.GazeProvider.GazeDirection;
            //Format Output
            
            
            string logInfo = String.Format("Gaze Origin: {0:0.000}, Gaze Hit: {1:0.000}, Gaze Object: {2}, " +
                                            "Gaze Look: {3:0.000}", gazeOrigin, gazeHit, gazeObject, gazeLook);
            
            FileWriter.AppendToFile(Application.persistentDataPath + "/" + "test4623.txt", logInfo);
            //Log to Console
            //Debug.Log(logInfo);

            yield return new WaitForSeconds(.1f);
        }

    }*/
}
