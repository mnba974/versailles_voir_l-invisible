using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class lowplane : MonoBehaviour
{
    public ARPlaneManager planeManager;
    public float lowest = Mathf.Infinity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (ARPlane plane in planeManager.trackables)
        {
            if (plane.transform.position.y < lowest)
            {
                lowest = plane.transform.position.y;
            }
        }
    }
}
