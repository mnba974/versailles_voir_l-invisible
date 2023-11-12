using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZommScan : MonoBehaviour
{
    public Touch touch1;
    public Touch touch2;
    public float Magnitude;
    float initialScale;
    void Start()
    {
        initialScale = gameObject.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 2)
        {
            touch1 = Input.GetTouch(0);
            touch2 = Input.GetTouch(1);
            if (touch1.phase == TouchPhase.Began && touch2.phase == TouchPhase.Began)
            {
                Magnitude = (touch1.position - touch2.position).magnitude + 1;
            }
            if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {
                float mag2 = (touch1.position - touch2.position).magnitude + 1;
                Vector3 newScale = gameObject.transform.localScale * mag2 / Magnitude;
                if (newScale.x < 1.5f * initialScale)
                {
                    gameObject.transform.localScale = newScale;
                }
                else
                {
                    gameObject.transform.localScale = new Vector3(1.5f * initialScale, 1.5f * initialScale, 1.5f * initialScale);
                }
                Magnitude = mag2;
            }
        }
    }
}
