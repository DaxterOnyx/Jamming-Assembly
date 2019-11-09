using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CorridorItemData", menuName = "ScriptableObjects/CorridorItemData")]
public class CorridorItemData : ScriptableObject
{
    public List<Sprite> spriteList;
    public List<Item> itemList;
}
