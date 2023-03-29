using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.UnityRoboticsDemo;

public class GazePublisherROS : MonoBehaviour
{
    ROSConnection ros;
    public string gazeDirection_topicName = "Gaze_Pos";
    public string gazeOrigin_topicName = "Gaze_Origin"
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
        float gazeDirectionX = CoreServices.InputSystem.EyeGazeProvider.GazeDirection.x;
        float gazeDirectionY = CoreServices.InputSystem.EyeGazeProvider.GazeDirection.y;
        float gazeDirectionZ = CoreServices.InputSystem.EyeGazeProvider.GazeDirection.z;

        float gazeOriginX = CoreServices.InputSystem.EyeGazeProvider.GazeOrigin.x;
        float gazeOriginY = CoreServices.InputSystem.EyeGazeProvider.GazeOrigin.y;
        float gazeOriginZ = CoreServices.InputSystem.EyeGazeProvider.GazeOrigin.z;
        

        timeElapsed += Time.deltaTime;

        if(timeElapsed > publishMessageFrequency)
        {
            PosRotMsg gazePos = new PosRotMsg(
                gazeDirectionX,
                gazeDirectionY,
                gazeDirectionZ,
                rotX,
                rotY,
                rotZ,
                rotW
                );

            PosRotMsg gazeOrigin = new PosRotMsg(
                gazeOriginX,
                gazeOriginY,
                gazeOriginZ,
                rotX,
                rotY,
                rotZ,
                rotW
            );

            ros.Publish(gazeDirection_topicName, gazePos);
            ros.Publish(gazeOrigin_topicName, gazeOrigin);

            timeElapsed = 0;
        }
    }
}
