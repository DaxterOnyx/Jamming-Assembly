using UnityEngine;
[CreateAssetMenu(fileName = "InventoryData", menuName = "ScriptableObjects/InventoryData")]
public class ItemData : ScriptableObject
{
	ItemData genericItemData;
	Effect[] effectsAccepted;
	Effect[] effectsUniqueAccepted;
	Vector2Int size;
}
