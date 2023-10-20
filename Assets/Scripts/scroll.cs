using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scroll : MonoBehaviour
{
    // Start is called before the first frame update
    string mode;
    void Start()
    {
        mode = GameObject.Find("spawnManager").GetComponent<SpawnableManager>().mode;
    }

    // Update is called once per frame
    void Update()
    {
       mode = GameObject.Find("spawnManager").GetComponent<SpawnableManager>().mode;
       if (Time.time> 0.05 )
        {
            if ( mode == "rotation" ) {
                gameObject.GetComponent<Image>().enabled = true;
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                gameObject.GetComponent<Image>().enabled = false;
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
        } 
    }
}
