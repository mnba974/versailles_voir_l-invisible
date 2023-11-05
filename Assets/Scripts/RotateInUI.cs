using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class RotateInUI : MonoBehaviour
{
    public Touch touch;
    public float rotSpeed = 1.0f;
    
    public Rigidbody rb;
    
    void Start()
    {
        if (gameObject.name != "UI_OBJ")
        {
            this.enabled = false;
        }
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0)
        {
            return;
        }
        touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            rb.angularVelocity = Vector3.zero;
        }
        if (touch.phase != TouchPhase.Moved)
        {
            rb.angularVelocity = new Vector3(touch.deltaPosition.y * rotSpeed, -touch.deltaPosition.x * rotSpeed, 0f);
            
        }

    }
}
