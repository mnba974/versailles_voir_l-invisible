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
    public List<ItemSO> items;

    private List<ItemSO> itemList = new List<ItemSO>();

    public ItemSO easterEgg;
    public List<string> list;
    
    
   
    // Start is called before the first frame update
    void OnEnable()
    {
        list = MainManager.Instance.items;
        foreach(var item in items)
        {
            if (list.Contains(item.name))
            {
                AddItem(item);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(ItemSO itemToAdd)
    {
        Transform item = content.transform.Find(itemToAdd.itemName);
        if (!list.Contains(itemToAdd.name))
        {
            MainManager.Instance.items.Add(itemToAdd.name);
        }
        if (item != null)
        {
            item.GetChild(0).GetComponent<Image>().sprite = itemToAdd.itemSprite;
            itemToAdd.discovered = true;
            itemList.Add(itemToAdd);
        }

        if (list.Count >= 9)
        {
            Transform item2 = content.transform.Find(easterEgg.itemName);
            if (item2 != null)
            {
                item2.GetChild(0).GetComponent<Image>().sprite = easterEgg.itemSprite;
                easterEgg.discovered = true;
                list.Add(itemToAdd.name);
            }

            ShowItem(easterEgg);
        }
    }

    public void ShowItem(ItemSO itemToShow)
    {
        if (itemToShow.discovered)
        {
            inventoryPanel.SetActive(false);
            backButton.SetActive(false);
            showPanel.SetActive(true);

            Transform nom = showPanel.transform.Find("Nom");
            nom.GetComponent<TextMeshProUGUI>().text = itemToShow.itemName;
            
            Transform explications = showPanel.transform.Find("Explications");
            explications.GetComponent<TextMeshProUGUI>().text = itemToShow.description;

            GameObject prefab = Instantiate(itemToShow.prefab);
            
            prefab.transform.SetParent(showPanel.transform, true);
            prefab.transform.localPosition = Vector3.zero;
            float scale = itemToShow.UIScale;
            prefab.transform.localScale = new Vector3(scale, scale, scale);
            prefab.name = "UI_OBJ";
         }
    }

    public void HideItem()
    {
        GameObject lastChild = showPanel.transform.GetChild(showPanel.transform.childCount- 1).gameObject;

        if (lastChild.name != "Explications")
        {
            Destroy(lastChild);
        }
    }
}
