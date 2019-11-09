using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData")]
public class ItemData : ScriptableObject
{
	public ItemData genericItemData;
	[SerializeField]
	private Effect[] effectsAccepted;
	[SerializeField]
	private Effect[] effectsUniqueAccepted;
	[SerializeField]
	private Effect[] effectsMandatory;
	public Vector2Int size;
	public Sprite miniSprite;
	public Sprite realSprite;

	public Effect[] EffectsAccepted
	{
		get {
			var effects = new List<Effect>(effectsAccepted);
			effects.AddRange(genericItemData.EffectsAccepted);
			return effects.ToArray();
		}
	}

	public Effect[] EffectsUniqueAccepted
	{
		get {
			var effects = new List<Effect>(effectsUniqueAccepted);
			effects.AddRange(genericItemData.EffectsUniqueAccepted);
			return effects.ToArray();
		}
	}

	public Effect[] EffectsMandatory
	{
		get {
			var effects = new List<Effect>(effectsMandatory);
			effects.AddRange(genericItemData.EffectsMandatory);
			return effects.ToArray();
		}
	}

}
