using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public bool discovered = false;
    public bool correctAnswer = false;
    public GameObject prefab;
    public Sprite itemSprite;
    [TextArea]
    public string description;
    public float UIScale = 10;

    public GameObject statue;
}
