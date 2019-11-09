using UnityEngine;
[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData")]
public class ItemData : ScriptableObject
{
	public ItemData genericItemData;
	public Effect[] effectsAccepted;
	public Effect[] effectsUniqueAccepted;
	public Effect[] effectsMandatory;
	public Vector2Int size;
	public Sprite miniSprite;
	public Sprite realSprite;
}
