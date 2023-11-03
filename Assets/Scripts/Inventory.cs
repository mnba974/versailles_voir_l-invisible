using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public GameObject content;
    public GameObject showPanel;
    public GameObject inventoryPanel;
    public GameObject backButton;

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
        Transform item = content.transform.Find(itemToAdd.itemName);
        if (item != null)
        {
            item.GetChild(0).GetComponent<Image>().sprite = itemToAdd.itemSprite;
            itemToAdd.discovered = true;
        }
    }

    public void ShowItem(ItemSO itemToShow)
    {
        if (itemToShow.discovered)
        {
            inventoryPanel.SetActive(false);
            showPanel.SetActive(true);
            backButton.SetActive(true);

            Transform nom = showPanel.transform.Find("Nom");
            nom.GetComponent<TextMeshProUGUI>().text = itemToShow.itemName;
            
            Transform explications = showPanel.transform.Find("Explications");
            explications.GetComponent<TextMeshProUGUI>().text = itemToShow.description;

            Instantiate(itemToShow.prefab, showPanel.transform);
        }
    }

    public void HideItem()
    {
        Transform lastChild = showPanel.transform.GetChild(-1);

        if (lastChild.name != "Explications")
        {
            Destroy(lastChild);
        }
    }
}