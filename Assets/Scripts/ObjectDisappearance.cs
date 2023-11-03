using UnityEngine;

public class ObjectDisappearance : MonoBehaviour
{
    public GameObject objectToDisappear;

    private void Start()
    {
        // Initialize the reference to the object
        objectToDisappear = this.gameObject;
    }

    public void DisappearObject()
    {
        objectToDisappear.SetActive(false);
    }
}
