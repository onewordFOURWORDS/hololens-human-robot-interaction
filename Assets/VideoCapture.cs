using System.Collections;
using System.Collections.Generic;
using System;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class VideoCapture : MonoBehaviour
{
    VideoCapture m_VideoCapture = null;
    // Start is called before the first frame update
    void Start()
    {
        VideoCapture.CreateAsync(false, OnVideoCaptureCreated);
    }

    void OnVideoCaptureCreated(VideoCapture videoCapture)
    {
        if (videoCapture != null)
        {
            m_VideoCapture = videoCapture;

            Resolution cameraResolution = VideoCapture.SupportedResolutions.OrderByDescending((res) => res.width * res.height).First();
            float cameraFramerate = VideoCapture.GetSupportedFrameRatesForResolution(cameraResolution).OrderByDescending((fps) => fps).First();

            CameraParameters cameraParameters = new CameraParameters();
            cameraParameters.hologramOpacity = 0.0f;
            cameraParameters.frameRate = cameraFramerate;
            cameraParameters.cameraResolutionWidth = cameraResolution.width;
            cameraParameters.cameraResolutionHeight = cameraResolution.height;
            cameraParameters.pixelFormat = CapturePixelFormat.BGRA32;

            m_VideoCapture.StartVideoModeAsync(cameraParameters,
                                                VideoCapture.AudioState.None,
                                                OnStartedVideoCaptureMode);
        }
        else
        {
            Debug.LogError("Failed to create VideoCapture Instance!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
