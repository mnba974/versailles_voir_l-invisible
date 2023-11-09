using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
public class Infos : MonoBehaviour
{
    public GameObject textPanel;
    public GameObject infoPanel;
    public List<GameObject> textsList;
    
    public Color color;
    public GameObject showPanel;

    public GameObject prefab;
    public void InfosStatue(ItemSO item)
    {
        foreach(GameObject text in textsList)
        {
            text.SetActive(false);
        }
        

        color = transform.GetChild(0).GetComponent<TextMeshProUGUI>().color;
        if (color == Color.white)
        {
            textPanel.SetActive(false);
            infoPanel.SetActive(true);
            
            Destroy(showPanel.transform.GetChild(showPanel.transform.childCount - 1).gameObject);

            prefab = Instantiate(item.statue);
            
            prefab.transform.position = showPanel.transform.position;
            prefab.transform.SetParent(showPanel.transform, true);
            prefab.name = "UI_OBJ";

            Rigidbody rb = prefab.AddComponent<Rigidbody>();
            rb.useGravity = false;
            rb.angularDrag = 4;

            RotateInUI RIUI = prefab.AddComponent<RotateInUI>();
            RIUI.rotSpeed = 0.1f;


        }
        //if (item.discovered)
        //{
        
        //}
    }
}
