using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public List<GameObject> prefabList = new List<GameObject>();
    // public TextMeshProUGUI ItemsPanel;
    // public GameObject InventoryPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(GameObject GOToAdd)
    {
        prefabList.Add(GOToAdd);
        // InventoryPanel.SetActive(true);
        // ItemsPanel.text = GOToAdd.name;
    }
}
