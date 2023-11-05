using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectéScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float start;
    void OnEnable()
    {
        start = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > start + 2) {
            gameObject.SetActive(false);
            
        }
    }
}
