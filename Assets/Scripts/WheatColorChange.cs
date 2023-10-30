using System.Collections;
using UnityEngine;

public class WheatColorChange : MonoBehaviour
{
    public Renderer objectRenderer;  // Reference to the object's renderer
    public float brightnessChangeSpeed = 0.1f;  // Speed of brightness change
    public float Brightness = 0.5f;  // Target brightness (adjust as needed)
    public float MaxBrightness = 0.7f;
    public float MinBrightness = 0.3f;

    private Material originalMaterial;  // Store the original material

    private bool increasingBrightness = false;  // Flag to control brightness change direction

    void Start()
    {
        // Ensure the object has a renderer component
        if (objectRenderer == null)
        {
            Debug.LogError("Object Renderer is not assigned!");
            enabled = false;  // Disable the script
            return;
        }

        // Store the object's original material
        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        // Change the brightness direction based on the flag
        if (increasingBrightness)
        {
            Brightness += Time.deltaTime * brightnessChangeSpeed;
        }
        else
        {
            Brightness -= Time.deltaTime * brightnessChangeSpeed;
        }

        // Check if the brightness exceeds the target
        if (Brightness >= MaxBrightness)
        {
            increasingBrightness = false;  // Start decreasing brightness
        }
        else if (Brightness <= MinBrightness)
        {
            increasingBrightness = true;  // Start increasing brightness
        }

        // Create a new color with the adjusted brightness
        Color newColor = new Color(Brightness*173/255, Brightness*204/255, Brightness*12/255);

        // Apply the new color to the material
        objectRenderer.material.color = newColor;
    }
}