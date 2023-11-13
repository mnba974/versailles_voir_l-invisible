using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    public ItemSO easterEgg;
    public GameObject easterEggButton;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (easterEgg.discovered)
        {
            easterEggButton.SetActive(true);
        }
    }
}
