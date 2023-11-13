using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARFoundation;

public class ResetScript : MonoBehaviour
{
    
    public ARSession arsession;
    
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Reset()
    {
        
        PlaceTrackedImages._instantiatedPrefabs.Clear();
        PlaceRotate._instantiatedPrefabs.Clear();
        BommerMode._instantiatedPrefabs.Clear();
        arsession.Reset();
        SceneManager.LoadScene("Menu");
        
        
    }
}
