using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorItem : MonoBehaviour
{
    public enum typeEnum
    {
        BAG = 0,
        CHEST = 1
    }

    private typeEnum type;
    public CorridorItemData data;

    public void Init()
    {
        transform.position = data.spawnPoint;

        // Randomisation de l'item
        if (UnityEngine.Random.value > data.bagPobability)
        {
            type = typeEnum.CHEST;
        }
        else
        {
            type = typeEnum.BAG;
        }

        switch (type)
        {
            case typeEnum.BAG:
                this.GetComponent<SpriteRenderer>().sprite = 
                    data.spriteListBag[Mathf.FloorToInt(UnityEngine.Random.Range(0, data.spriteListBag.Count))];
                break;
            case typeEnum.CHEST:
                this.GetComponent<SpriteRenderer>().sprite =
                    data.spriteListChest[Mathf.FloorToInt(UnityEngine.Random.Range(0, data.spriteListChest.Count))];
                break;
            default:
                break;
        }
    }
}
