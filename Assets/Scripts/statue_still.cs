using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statue_still : MonoBehaviour
{
    public float l;
    public GameObject lowestplane;
    // Start is called before the first frame update
    void Start()
    {
        lowestplane = GameObject.Find("lowplaneposition");
    }

    // Update is called once per frame
    void Update()
    {
        l = lowestplane.GetComponent<lowplane>().lowest;
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        transform.position = new Vector3(transform.position.x, l ,transform.position.z);
    }
}
