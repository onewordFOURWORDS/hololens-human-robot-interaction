using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.UnityRoboticsDemo;

public class GazePublisherROS : MonoBehaviour
{
    ROSConnection ros;
    public string topicName = "Gaze_Pos";
    public float publishMessageFrequency = 0.1f;
    private float timeElapsed;
    private float rotX = 0;
    private float rotY = 0;
    private float rotZ = 0;
    private float rotW = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<PosRotMsg>(topicName);
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if(timeElapsed > publishMessageFrequency)
        {
            PosRotMsg gazePos = new PosRotMsg(
                CoreServices.InputSystem.GazeProvider.GazeDirection.x,
                CoreServices.InputSystem.GazeProvider.GazeDirection.y,
                CoreServices.InputSystem.GazeProvider.GazeDirection.z,
                rotX,
                rotY,
                rotZ,
                rotW
                );

            ros.Publish(topicName, gazePos);

            timeElapsed = 0;
        }
    }
}
