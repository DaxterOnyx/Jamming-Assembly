using UnityEngine;
[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData")]
public class ItemData : ScriptableObject
{
	ItemData genericItemData;
	Effect[] effectsAccepted;
	Effect[] effectsUniqueAccepted;
	Effect[] effectsMandatory;
	Vector2Int size;
}
