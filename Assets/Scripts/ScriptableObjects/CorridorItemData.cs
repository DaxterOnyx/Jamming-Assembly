using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CorridorItemData", menuName = "ScriptableObjects/CorridorItemData")]
public class CorridorItemData : ScriptableObject
{
    public GameObject generalItem;
    public Vector3 spawnPoint;
    public List<Sprite> spriteListBag;
    public List<ItemData> itemListBag;
    public float bagPobability;
    public List<Sprite> spriteListChest;
    public List<ItemData> itemListChest;
}
