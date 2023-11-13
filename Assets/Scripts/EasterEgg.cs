using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    public ItemSO easterEgg;
    public GameObject easterEggButton;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        if (MainManager.Instance.items.Count >= 9)
        {
            easterEggButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
