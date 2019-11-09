using UnityEngine;
[CreateAssetMenu(fileName = "InventoryData", menuName = "ScriptableObjects/InventoryData")]
public class ItemData : ScriptableObject
{
	ItemData genericItemData;
	Effect[] effectsAccepted;
	Effect[] effectsUniqueAccepted;
	Effect[] effectsMandatory;
	Vector2Int size;
}
