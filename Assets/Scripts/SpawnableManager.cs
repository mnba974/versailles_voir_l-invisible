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
    Camera arCam;
    GameObject spawnedObject;
    public GameObject stat;
    public TMP_Text cloth;
    public Rigidbody rigidbody;
    public bool moving = false;
    public float time;
    public float duration = 2;
    public float movement_speed = 3;
    public float direction = -1;
    void Start()
    {
        spawnedObject = null;
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
    }
    void Update()
    {
        if (moving && time < duration)
        {
            cloth.text = time.ToString();
            rigidbody.position = rigidbody.position + Vector3.up * Time.deltaTime * movement_speed * direction;
            time = time + Time.deltaTime;
        }

        if (Input.touchCount == 0)
        {
            return;
        }

        RaycastHit hit;
        Ray ray= arCam.ScreenPointToRay(Input.GetTouch(0).position);
        if (m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits))
        {
        if(Input.GetTouch(0).phase == TouchPhase.Began && spawnedObject == null)
        {
            if (Physics.Raycast(ray, out hit))
                    {
                    if (hit.collider.gameObject.tag == "ball")
                    {
                        rigidbody = GameObject.FindGameObjectWithTag("cl").GetComponent<Rigidbody>();
                        moving = true;
                        direction = -direction;
                        time = 0;
                        cloth.text = time.ToString() +" " + rigidbody.gameObject.name;
                    }
                    if (hit.collider.gameObject.tag == "spawnable")
                    {
                        stat.SetActive(true);
                        spawnedObject = hit.collider.gameObject;
                    }

                    else
                    {
                        SpawnPrefab(m_Hits[0].pose.position);
                    }
                    }

        }
        else if(Input.GetTouch(0).phase == TouchPhase.Moved && spawnedObject != null)
        {
            spawnedObject.transform.position = m_Hits[0].pose.position;
        }
        if(Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                spawnedObject = null;
                }
            }
        }


private void SpawnPrefab(Vector3 spawnPosition)
{
    spawnedObject = Instantiate(spawnablePrefab, spawnPosition, Quaternion.identity);
}
}
