using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class PlaceRotate : MonoBehaviour
{
    private Collider collide;
    public GameObject detect;
    public GameObject toucheSol;
    [SerializeField] ARRaycastManager m_RaycastManager;
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();
    Camera arCam;
    public GameObject buttonsPanel;
    // Reference to AR tracked image manager component
    private ARTrackedImageManager _trackedImagesManager;

    // List of prefabs to instantiate - these should be named the same
    // as their corresponding 2D images in the reference image library 
    
    public Animator canvas;

    public GameObject[] ArPrefabs;

    public GameObject prefab;
    public static GameObject lastPrefab;
    // Keep dictionary array of created prefabs
    public static Dictionary<string, GameObject> _instantiatedPrefabs = new Dictionary<string, GameObject>();

    void Awake()
    {
        // Cache a reference to the Tracked Image Manager component
        _trackedImagesManager = GetComponent<ARTrackedImageManager>();
    }
    private void Start()
    {
        detect = GameObject.Find("detect");
        toucheSol = GameObject.Find("Touche_sol");
        detect.SetActive(false);
        toucheSol.SetActive(false);
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
    }

    void OnEnable()
    {
        // Attach event handler when tracked images change
        _trackedImagesManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        // Remove event handler
        _trackedImagesManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    // Event Handler
    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {

        // Loop through all new tracked images that have been detected
        foreach (var trackedImage in eventArgs.added)
        {
            // Get the name of the reference image
            var imageName = trackedImage.referenceImage.name;
            detect.SetActive(true);
            toucheSol.SetActive(true);

            Transform button = buttonsPanel.transform.Find(imageName);

            if (button != null)
            {
                button.GetComponent<Image>().color = Color.white;
            }

            canvas.SetTrigger("infos");
            // Now loop over the array of prefabs
            foreach (var curPrefab in ArPrefabs)
            {
                // Check whether this prefab matches the tracked image name, and that
                // the prefab hasn't already been created
                if (string.Compare(curPrefab.name, imageName, StringComparison.OrdinalIgnoreCase) == 0
                    && !_instantiatedPrefabs.ContainsKey(imageName))
                {
                    prefab = curPrefab;
                    _instantiatedPrefabs[imageName] = prefab;

                }
            }
        }
        

    }
    

    void Update()
    {
        if (Input.touchCount == 0)
        {
            return;
        }


        RaycastHit hit;
        Ray ray = arCam.ScreenPointToRay(Input.GetTouch(0).position);

        if (m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits))
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began )
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (prefab != null)
                    {
                        SpawnPrefab(m_Hits[0].pose.position);
                        toucheSol.SetActive(false);
                        lastPrefab = prefab;
                    }

                    else if (hit.collider.gameObject.tag == "spawnable")
                    {

                        prefab = hit.collider.gameObject;
                        lastPrefab = hit.collider.gameObject;
                        collide = prefab.GetComponent<Collider>();
                        collide.enabled = false;

                    }
                    
                    
                }

            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved && prefab != null )
            {

                prefab.transform.position = new Vector3(m_Hits[0].pose.position.x, lowplane.lowest , m_Hits[0].pose.position.z);
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
            if (lastPrefab == prefab) 
                {
                    prefab = null;
                }
             
             collide.enabled = true;
                
            }
        }
    }

    private void SpawnPrefab(Vector3 spawnPosition)
    {
        prefab = Instantiate(prefab, spawnPosition, Quaternion.identity);
    }

}