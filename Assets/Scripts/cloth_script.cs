using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloth_script : MonoBehaviour
{
    public Rigidbody rigidbody;
    public bool moving = false;
    public float time;
    public float duration = 2;
    public float movement_speed = 3;
    public float direction = -1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moving && time < duration)
        {
            rigidbody.position = rigidbody.position + Vector3.up * Time.deltaTime * movement_speed * direction;
            time = time + Time.deltaTime;
            if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
            {
                Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit raycastHit;
                if (Physics.Raycast(raycast, out raycastHit))
                {
                    Debug.Log("Something Hit");
                    if (raycastHit.collider.CompareTag("SoccerTag"))
                    {
                        Debug.Log("Soccer Ball clicked");
                    }
                }
            }
            void Update()
            {
                if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
                {
                    Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    RaycastHit raycastHit;
                    if (Physics.Raycast(raycast, out raycastHit))
                    {
                        Debug.Log("Something Hit");
                        if (raycastHit.collider.name == "Soccer")
                        {
                            Debug.Log("Soccer Ball clicked");
                        }

                        //OR with Tag

                        if (raycastHit.collider.CompareTag("ball"))
                        {
                            moving = true;
                            direction = -direction;
                            time = 0;
                        }
                    }
                }
            }

        }
    }
}