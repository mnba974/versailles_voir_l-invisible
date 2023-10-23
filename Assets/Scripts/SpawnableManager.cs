using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class SpawnableManager : MonoBehaviour
{
    [SerializeField] ARRaycastManager m_RaycastManager;
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();
    [SerializeField] GameObject spawnablePrefab;
    public List<GameObject> spawnables;
    Camera arCam;
    GameObject spawnedObject;

    public GameObject stat;
    public TMP_Text cloth;

    public Scrollbar scrollrot;
    public Scrollbar scrollscale;
    public  bool destroymode= false;
    int pointer = 0;

    public string mode;

    public  void switchstatue()
    {
        if (pointer == spawnables.Count-1)
        {
            pointer = 0;
        }
        else
        {
            pointer += 1;
        }
    }
    public void Destroymode()
    {
        mode = "destroy";
    }
    public void Placemode()
    {
        mode = "place";
    }

    public void Rotationmode()
    {
        mode = "rotation";
    }
    public void Scalemode()
    {
        mode = "scale";
    }



    void Start()
    {
        spawnablePrefab = spawnables[0];
        spawnedObject = null;
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
        mode = "place";
        scrollrot = GameObject.Find("rotation").GetComponent<Scrollbar>();
        scrollscale = GameObject.Find("scale").GetComponent<Scrollbar>();

    }
    void Update()
    {
        if (Input.touchCount == 0)
        {
            return;
        }

        if (mode == "rotation" && spawnedObject != null)
        {
            float yrot = scrollrot.value * 360.0f;
            spawnedObject.transform.rotation = Quaternion.Euler(0, yrot, 0);
        }
        if (mode == "scale" && spawnedObject != null)
        {
            float scl = Mathf.Pow(10, scrollscale.value);
            spawnedObject.transform.localScale = new Vector3(scl, scl, scl);
        }

        spawnablePrefab = spawnables[pointer];

        RaycastHit hit;
        Ray ray= arCam.ScreenPointToRay(Input.GetTouch(0).position);
        if (m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits))
        {
        if(Input.GetTouch(0).phase == TouchPhase.Began && (spawnedObject == null || mode == "rotation" || mode == "scale"))
            {
            if (Physics.Raycast(ray, out hit))
                    {
                    if (hit.collider.gameObject.tag == "spawnable")
                    {
                        
                        spawnedObject = hit.collider.gameObject;
                        if (mode == "destroy")
                        {
                            Destroy(spawnedObject);
                        }
                    }
                   

                    else if (mode =="place")
                    {
                        SpawnPrefab(m_Hits[0].pose.position);
                    }
                    }

        }
        else if(Input.GetTouch(0).phase == TouchPhase.Moved && spawnedObject != null && mode == "place")
        {
            
            spawnedObject.transform.position = m_Hits[0].pose.position;
        }

        if(Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                if (mode != "rotation" && mode !="scale")
                {
                    spawnedObject = null;
                }
                }
            }
        }


private void SpawnPrefab(Vector3 spawnPosition)
{
    spawnedObject = Instantiate(spawnablePrefab, spawnPosition, Quaternion.identity);
}
}
