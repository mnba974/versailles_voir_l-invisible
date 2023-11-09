using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Infos : MonoBehaviour
{
    public GameObject textPanel;
    public GameObject infoPanel;
    public List<GameObject> textsList;
    public GameObject buttonsPanel;
    public Color color;
    public void InfosStatue(ItemSO item)
    {
        foreach(GameObject text in textsList)
        {
            text.SetActive(false);
        }
        Transform button = buttonsPanel.transform.Find(item.prefab.name);

        if (button != null)
            {
            color = button.GetComponent<Image>().color;
            }
        if (color == Color.white)
        {
            textPanel.SetActive(false);
            infoPanel.SetActive(true);
        }
        //if (item.discovered)
        //{
        
        //}
    }
}
