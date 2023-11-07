using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject slider;
    void Start()
    {
        slider.SetActive(false);
    }

    // Update is called once per frame
    public void Tap()
    {
        if (slider.activeSelf) {
            slider.SetActive (false);
        }
        else
        {
            slider.SetActive (true);
        }
    }
}
