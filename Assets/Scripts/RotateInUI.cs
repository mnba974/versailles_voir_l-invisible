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
        AutoTurn();


    }

    void AutoTurn()
    {
        if (gameObject.tag == "Statue")
        {
            rb.angularVelocity = new Vector3(0, -10 * rotSpeed, 0f);
            rb.angularDrag = 0;
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
        if (touch.phase == TouchPhase.Began)
        {
            if (gameObject.tag == "Statue")
            {
                rb.angularVelocity = new Vector3(0, 0, 0);
                rb.angularDrag = 4;
            }
        }
        if (touch.phase == TouchPhase.Moved)
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
        
        if (touch.phase == TouchPhase.Ended) 
        {
            Invoke("AutoTurn", 5.0f);
        }

    }
}
