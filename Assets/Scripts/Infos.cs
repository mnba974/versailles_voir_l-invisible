using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infos : MonoBehaviour
{
    public GameObject textPanel;
    public GameObject infoPanel;
    public List<GameObject> textsList;

    public void InfosStatue(ItemSO item)
    {
        foreach(GameObject text in textsList)
        {
            text.SetActive(false);
        }

        if (item.discovered)
        {
            textPanel.SetActive(false);
            infoPanel.SetActive(true);
        }
    }
}
