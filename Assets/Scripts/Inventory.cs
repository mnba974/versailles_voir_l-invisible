using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject content;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(ItemSO itemToAdd)
    {
        GameObject item = content.transform.Find(itemToAdd.itemName).gameObject;
        if (item != null)
        {
            item.GetComponentInChildren<Image>().sprite = itemToAdd.itemSprite;
        }
    }
}
