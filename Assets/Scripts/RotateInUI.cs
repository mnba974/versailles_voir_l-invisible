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
        rb = GetComponent<Rigidbody>();
        if (gameObject.name != "UI_OBJ")
        {
            Destroy(rb);
            this.enabled = false;
            
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0)
        {
            return;
        }
        touch = Input.GetTouch(0);
        
        if (touch.phase != TouchPhase.Moved)
        {
            if (gameObject.tag == "Statue")
            {
                rb.angularVelocity = new Vector3(0, -touch.deltaPosition.x * rotSpeed, 0f);
            }
            else
            {
                rb.angularVelocity = new Vector3(touch.deltaPosition.y * rotSpeed, -touch.deltaPosition.x * rotSpeed, 0f);
            }
            
        }

    }
}
