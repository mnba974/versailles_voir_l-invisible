using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class debug : MonoBehaviour
{
    public GameObject debugGameObject;
    public float l;
    public TextMeshProUGUI t;
    // Start is called before the first frame update
    void Start()
    {
        t = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        l = debugGameObject.GetComponent<lowplane>().lowest;
        t.text = l.ToString();
    }
}
