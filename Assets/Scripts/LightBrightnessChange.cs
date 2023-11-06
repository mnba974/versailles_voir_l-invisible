using UnityEngine;

public class LightBrightnessChange : MonoBehaviour
{
    public float speed = 1.0f;          // Speed of brightness change
    public float maxBrightness = 1.0f; // Maximum brightness
    public float minBrightness = 0.0f; // Minimum brightness

    private Light pointLight;
    private float currentBrightness = 0.0f;
    private float direction = 1.0f; // 1 for increasing brightness, -1 for decreasing

    void Start()
    {
        pointLight = GetComponent<Light>();
    }

    void Update()
    {
        // Change the brightness
        currentBrightness += speed * Time.deltaTime * direction;

        // Check if it's time to reverse direction
        if (currentBrightness >= maxBrightness)
        {
            currentBrightness = maxBrightness;
            direction = -1.0f;
        }
        else if (currentBrightness <= minBrightness)
        {
            currentBrightness = minBrightness;
            direction = 1.0f;
        }

        // Apply the current brightness to the point light
        pointLight.intensity = currentBrightness;
    }
}
