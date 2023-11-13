using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class RotateInUI : MonoBehaviour
{
    public Touch touch;
    public Touch touch1;
    public Touch touch2;
    public float Magnitude;
    public float rotSpeed = 1.0f;
    public GameObject Image;
    public Rigidbody rb;

    float initialScale;
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        if (gameObject.name != "UI_OBJ")
        {
            Destroy(rb);
            this.enabled = false;
            
        }
        
        AutoTurn();
        
        if (gameObject.tag == "Statue")
        {
            transform.localScale = transform.localScale * 2;
        }

        initialScale = gameObject.transform.localScale.x;


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
        if (Input.touchCount == 1)
        {
            
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

        if (Input.touchCount == 2)
        {
            touch1 = Input.GetTouch(0);
            touch2 = Input.GetTouch(1);
            if (touch1.phase == TouchPhase.Began && touch2.phase == TouchPhase.Began)
            {
                Magnitude = (touch1.position - touch2.position).magnitude +1;
            }
            else if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {
                float mag2 = (touch1.position - touch2.position).magnitude+1;
                Vector3 newScale = gameObject.transform.localScale * mag2/Magnitude;
                if (newScale.x < 1.5f *initialScale)
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
