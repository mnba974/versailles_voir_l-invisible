using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infos : MonoBehaviour
{
    public GameObject textPanel;
    public GameObject infoPanel;

    public void InfosStatue(ItemSO item)
    {
        if (item.discovered)
        {
            textPanel.SetActive(false);
            infoPanel.SetActive(true);
        }
    }
}
