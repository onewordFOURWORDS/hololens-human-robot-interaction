using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;

public class ObjectInteration : MonoBehaviour
{
    public GameObject sphere1;
    public GameObject sphere2;
    private int defaultDistance = 5;

    private Material _sphere1Material;
    private Material _sphere2Material;

    private bool _sphereHeld;
    private bool _sphere1Held;
    private bool _sphere2Held;

    private float _timeElapsed;
    public float dataLogFreq = 0.1f;
    
    private void Start()
    {
        _sphere1Material = sphere1.GetComponent<Renderer>().material;
        _sphere2Material = sphere2.GetComponent<Renderer>().material;
    }
    
    public void GrabObject()
    {
        
        
        if (CoreServices.InputSystem.EyeGazeProvider.GazeTarget == sphere1 && !_sphereHeld)
        {
            sphere1.transform.position = CoreServices.InputSystem.EyeGazeProvider.GazeOrigin +
                                         CoreServices.InputSystem.EyeGazeProvider.GazeDirection.normalized *
                                         defaultDistance;

            _sphere1Material.color = Color.green;

            _sphereHeld = true;
            _sphere1Held = true;

        }

        if (CoreServices.InputSystem.EyeGazeProvider.GazeTarget == sphere2 && !_sphereHeld)
        {
            sphere2.transform.position = CoreServices.InputSystem.EyeGazeProvider.GazeOrigin +
                                         CoreServices.InputSystem.EyeGazeProvider.GazeDirection.normalized *
                                         defaultDistance;
            
            _sphere2Material.color = Color.green;

            _sphereHeld = true;
            _sphere2Held = true;
        }
    }

    public void PlaceObject()
    {
        if (CoreServices.InputSystem.EyeGazeProvider.GazeTarget == sphere1 && _sphereHeld)
        {
            sphere1.transform.position = sphere1.transform.position;

            _sphere1Material.color = Color.red;

            _sphereHeld = false;
            _sphere1Held = false;
        }

        if (CoreServices.InputSystem.EyeGazeProvider.GazeTarget == sphere2 && _sphereHeld)
        {
            sphere2.transform.position = sphere2.transform.position;
            _sphere2Material.color = Color.red;

            _sphereHeld = false;
            _sphere2Held = false;
        }
    }

    public void Update()
    {
        _timeElapsed += Time.deltaTime;

        if (_timeElapsed > dataLogFreq && _sphereHeld && CoreServices.InputSystem.EyeGazeProvider.GazeTarget == sphere1 && _sphere1Held)
        {
            sphere1.transform.position = CoreServices.InputSystem.EyeGazeProvider.GazeOrigin +
                                         CoreServices.InputSystem.EyeGazeProvider.GazeDirection.normalized *
                                         defaultDistance;

            _timeElapsed = 0; 
        }

        if (_timeElapsed > dataLogFreq && _sphereHeld && CoreServices.InputSystem.EyeGazeProvider.GazeTarget == sphere2 && _sphere2Held)
        {
            sphere2.transform.position = CoreServices.InputSystem.EyeGazeProvider.GazeOrigin +
                                         CoreServices.InputSystem.EyeGazeProvider.GazeDirection.normalized *
                                         defaultDistance;

            _timeElapsed = 0;
        }
        
    }
}
