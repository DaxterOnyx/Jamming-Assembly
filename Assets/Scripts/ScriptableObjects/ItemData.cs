using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData", order = -10)]
public class ItemData : ScriptableObject
{
	public ItemData genericItemData;
	[SerializeField]
	private Effect[] effectsAccepted;
	[SerializeField]
	private Effect[] effectsUniqueAccepted;
	[SerializeField]
	private Effect[] effectsMandatory;
	public Vector2Int size = new Vector2Int(1, 1);
	public Sprite miniSprite;
	public Sprite realSprite;
	[SerializeField]
	private Type _type;
	public enum Type
	{
		Undefinded = 0,
		Helmet,
		Accesory,
		Weapon,
		Shield,
		Boot,
		Consumable
	}
	public Effect[] EffectsAccepted
	{
		get {
			var effects = new List<Effect>(effectsAccepted);
			effects.AddRange(genericItemData?.EffectsAccepted);
			return effects.ToArray();
		}
	}

	public Effect[] EffectsUniqueAccepted
	{
		get {
			var effects = new List<Effect>(effectsUniqueAccepted);
			effects.AddRange(genericItemData?.EffectsUniqueAccepted);
			return effects.ToArray();
		}
	}

	public Effect[] EffectsMandatory
	{
		get {
			var effects = new List<Effect>(effectsMandatory);
			effects.AddRange(genericItemData?.EffectsMandatory);
			return effects.ToArray();
		}
	}

	public Type type
	{
		get {
			if (_type == Type.Undefinded && genericItemData != null)
				return genericItemData.type;
			else
				return _type;
		}
	}

}

