using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SliderRotation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject statue;
    public Slider scrollrot;
    void Start()
    {
        statue = PlaceRotate.lastPrefab;
        scrollrot = GetComponent<Slider>();
    }

    // Update is called once per frame
    
    public void ChnagedValue()
    {
        if (statue != PlaceRotate.lastPrefab)
        {
            statue = PlaceRotate.lastPrefab;
            scrollrot.value = statue.transform.rotation.eulerAngles.y/360.0f;
        }
        statue = PlaceRotate.lastPrefab;
        float yrot = scrollrot.value * 360.0f;
        statue.transform.rotation = Quaternion.Euler(0, yrot, 0);
    }
}
