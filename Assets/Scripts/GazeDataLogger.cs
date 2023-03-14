using System.Collections;
using System.Collections.Generic;
using System;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;

public class GazeDataLogger : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(GazeLogger());
    }

    private void Update()
    {
        //string yeet = TestGazeLogger();
        //Debug.Log(yeet);
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
            string log_info = String.Format("Gaze Origin: {0:0.00}, Gaze Hit: {1:0.00}, Gaze Object: {2}, " +
                                            "Gaze Look: {3:0.00}", GazeOrigin, GazeHit, GazeObject, GazeLook);
            //Log to Console
            Debug.Log(log_info);

            yield return new WaitForSeconds(.1f);
        }

    }

    string TestGazeLogger()
    {
        Vector3 GazeOrigin = CoreServices.InputSystem.GazeProvider.GazeOrigin;
        //Vector3 GazeHit = CoreServices.InputSystem.GazeProvider.HitPosition;
        //string GazeObject = CoreServices.InputSystem.GazeProvider.GazeTarget.ToString();
        Vector3 GazeLook = CoreServices.InputSystem.GazeProvider.GazeDirection;
        //Format it?
        string Gaze_Origin = String.Format("{0:0.00}", GazeOrigin);
        //string Gaze_Hit = String.Format("{0:0.00}", GazeHit);
        //string Gaze_Object = String.Format("{0:0.00}", GazeObject);
        string Gaze_Look = String.Format("{0:0.00}", GazeLook);
        string log_info = String.Format("Gaze Origin: {0:0.00}, Gaze Hit: {1}, Gaze Object: {2}, Gaze Look: {3}",
            GazeOrigin, "Gaze_Hit", "Gaze_Object", Gaze_Look);

        return log_info;
    }
}
