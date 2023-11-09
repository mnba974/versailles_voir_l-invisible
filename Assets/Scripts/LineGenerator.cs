using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    public GameObject linePrefab;
    GameObject newLine;
    RaycastHit hit;
    public Camera arCam;

    LineScript activeLine;
    


    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >0 )
        {
            
            Ray ray = arCam.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Draw")
                {
                    newLine = Instantiate(linePrefab);
                    newLine.transform.SetParent(hit.transform, true);
                    activeLine = newLine.GetComponent<LineScript>();
                }

            }
            
        }
        if (Input.touchCount == 0 && activeLine != null)
        {
            
            activeLine = null;
        }

        else if (activeLine != null)
        {
            
            Ray ray = arCam.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Draw")
                {
                    activeLine.UpdateLine(hit.point);
                }

            }
        }

        

        }
    }
        
