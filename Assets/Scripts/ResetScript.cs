using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARFoundation;

public class ResetScript : MonoBehaviour
{
    
    public ARSession arsession;
    public List<ItemSO> Items;
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Reset()
    {
        foreach (ItemSO item in Items)
        {
            item.discovered = false;
        }
        PlaceTrackedImages._instantiatedPrefabs.Clear();
        PlaceRotate._instantiatedPrefabs.Clear();
        arsession.Reset();
        SceneManager.LoadScene("Menu");
        
        
    }
}
