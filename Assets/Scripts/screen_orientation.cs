using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screen_orientation : MonoBehaviour
{
    public GameObject portrait;
    public GameObject landscape;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Screen.orientation == ScreenOrientation.Portrait)
        {
            landscape.SetActive(false);
            portrait.SetActive(true);
        }
        else
        {
            landscape.SetActive(true);
            portrait.SetActive(false);
        }
    }
}
