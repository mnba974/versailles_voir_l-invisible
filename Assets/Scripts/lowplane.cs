using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class lowplane : MonoBehaviour
{
    public ARPlaneManager planeManager;
    public static float lowest = 400;
    public float CurLowest = Mathf.Infinity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (ARPlane plane in planeManager.trackables)
        {
            if (plane.transform.position.y < CurLowest)
            {
                CurLowest = plane.transform.position.y;
            }
        }
        lowest = CurLowest;
        CurLowest = Mathf.Infinity;
    }
}
