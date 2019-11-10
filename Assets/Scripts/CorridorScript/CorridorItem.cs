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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (type)
        {
            case typeEnum.BAG:
                GameObject itemBag = Instantiate(data.generalItem);
                itemBag.GetComponent<Item>().Init(data.itemListBag[Mathf.FloorToInt(UnityEngine.Random.Range(0, data.itemListBag.Count))]);
                DropItemManager.Instance.AddItem(itemBag.GetComponent<Item>());
                break;
            case typeEnum.CHEST:
                GameObject itemChest = Instantiate(data.generalItem);
                itemChest.GetComponent<Item>().Init(data.itemListChest[Mathf.FloorToInt(UnityEngine.Random.Range(0, data.itemListChest.Count))]);
                DropItemManager.Instance.AddItem(itemChest.GetComponent<Item>());
                break;
            default:
                break;
        }
        Destroy(this.gameObject);
    }
}
