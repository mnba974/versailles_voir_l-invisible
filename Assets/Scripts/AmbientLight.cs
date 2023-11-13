using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class AmbientLight : MonoBehaviour
{
    [SerializeField] private ARCameraManager cameraManager;
    private Light light;


    private void Awake()
    {
        light = GetComponent<Light>();
    }
    private void OnEnable()
    {
        cameraManager.frameReceived += frameUpdate;
    }

    private void OnDisable()
    {
        cameraManager.frameReceived -= frameUpdate;
    }

    void frameUpdate(ARCameraFrameEventArgs args)
    {
        if (args.lightEstimation.averageBrightness.HasValue)
        {
            light.intensity = args.lightEstimation.averageBrightness.Value;
        }
        if (args.lightEstimation.averageColorTemperature.HasValue)
        {
            light.colorTemperature = args.lightEstimation.averageColorTemperature.Value;
        }
        if (args.lightEstimation.colorCorrection.HasValue)
        {
            light.color = args.lightEstimation.colorCorrection.Value;
        }
    }
}
