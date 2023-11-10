using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

[RequireComponent(typeof(ARTrackedImageManager))]
public class PlaceTrackedImages : MonoBehaviour
{
    public float offset;
    public GameObject detect;
    public GameObject text;
    // Reference to AR tracked image manager component
    private ARTrackedImageManager _trackedImagesManager;

    // List of prefabs to instantiate - these should be named the same
    // as their corresponding 2D images in the reference image library 
    public GameObject[] ArPrefabs;
   

    // Keep dictionary array of created prefabs
    public static Dictionary<string, GameObject> _instantiatedPrefabs = new Dictionary<string, GameObject>();


    public GameObject buttonsPanel;

    void Awake()
    {
        // Cache a reference to the Tracked Image Manager component
        _trackedImagesManager = GetComponent<ARTrackedImageManager>();
    }
    private void Start()
    {
        detect = GameObject.Find("detect");
        detect.SetActive(false);
        
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

            Transform button = buttonsPanel.transform.Find(imageName);

            if (button != null)
            {
                button.GetComponent<Image>().color = Color.white;
            }
            // Now loop over the array of prefabs
            foreach (var curPrefab in ArPrefabs)
            {
                // Check whether this prefab matches the tracked image name, and that
                // the prefab hasn't already been created
                if (string.Compare(curPrefab.name, imageName, StringComparison.OrdinalIgnoreCase) == 0
                    && !_instantiatedPrefabs.ContainsKey(imageName))
                {
                    // Instantiate the prefab, parenting it to the ARTrackedImage
                    var newPrefab = Instantiate(curPrefab);
                    // Add the created prefab to our array
                    newPrefab.transform.position = new Vector3(trackedImage.transform.position.x, trackedImage.transform.position.y, trackedImage.transform.position.z +offset);
                    _instantiatedPrefabs[imageName] = newPrefab;
                    text.SetActive(true);

                    
                }
            }
        }
        foreach (var trackedImage in eventArgs.updated)
        {
            var imageName = trackedImage.referenceImage.name;
            float y = trackedImage.transform.rotation.eulerAngles.y * MathF.PI/180.0f;
            _instantiatedPrefabs[imageName].transform.position = new Vector3(trackedImage.transform.position.x + offset * Mathf.Sin(y), trackedImage.transform.position.y, trackedImage.transform.position.z + offset* MathF.Cos(y));
            _instantiatedPrefabs[imageName].transform.rotation = Quaternion.Euler(0, trackedImage.transform.rotation.eulerAngles.y, 0);
        }


        }
}