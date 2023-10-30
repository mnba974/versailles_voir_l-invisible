using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class PlaceTrackedImages : MonoBehaviour
{
    public GameObject text;
    // Reference to AR tracked image manager component
    private ARTrackedImageManager _trackedImagesManager;

    // List of prefabs to instantiate - these should be named the same
    // as their corresponding 2D images in the reference image library 
    public GameObject[] ArPrefabs;

    // Keep dictionary array of created prefabs
    private readonly Dictionary<string, GameObject> _instantiatedPrefabs = new Dictionary<string, GameObject>();

    void Awake()
    {
        // Cache a reference to the Tracked Image Manager component
        _trackedImagesManager = GetComponent<ARTrackedImageManager>();
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
                    newPrefab.transform.position = trackedImage.transform.position;
                    _instantiatedPrefabs[imageName] = newPrefab;
                    text.SetActive(true);
                    
                }
            }
        }
        foreach (var trackedImage in eventArgs.updated)
        {
            var imageName = trackedImage.referenceImage.name;
            _instantiatedPrefabs[imageName].transform.position = trackedImage.transform.position;
            _instantiatedPrefabs[imageName].transform.rotation = Quaternion.Euler(0, trackedImage.transform.rotation.eulerAngles.y +180, 0);
        }


        }
}