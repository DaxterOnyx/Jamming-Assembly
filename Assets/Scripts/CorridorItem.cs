using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorItem : MonoBehaviour
{
    public CorridorItemData data;

    private List<Sprite> possibleSprite;
    private List<Item> possibleItem;

    private void Start()
    {
        possibleSprite = data.spriteList;
        possibleItem = data.itemList;
    }

    internal GameObject SpawnItem()
    {
        GameObject corridorItem = new GameObject();
        corridorItem.AddComponent<CorridorItem>();
        corridorItem.AddComponent<SpriteRenderer>();
        corridorItem.GetComponent<SpriteRenderer>().sprite = possibleSprite[Mathf.FloorToInt(UnityEngine.Random.Range(0, possibleSprite.Count))];
        return corridorItem;
    }
}
