using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData", order = -10)]
public class ItemData : ScriptableObject
{
	public ItemData genericItemData;
	[SerializeField]
	private EffectData[] effectsAccepted;
	[SerializeField]
	private EffectData[] effectsUniqueAccepted;
	[SerializeField]
	private EffectData[] effectsMandatory;
	public Vector2Int size = new Vector2Int(1, 1);
	public Sprite miniSprite;
	public Sprite realSprite;
	public int maxEffects;
	public int maxUniqueEffects;


	[SerializeField]
	private Type _type;
	public enum Type
	{
		Undefinded = 0,
		Helmet,
		Accesory,
		Weapon,
		Armor,
		Shield,
		Boot,
		Consumable
	}
	public EffectData[] EffectsAccepted
	{
		get {
			var effects = new List<EffectData>(effectsAccepted);
			effects.AddRange(genericItemData?.EffectsAccepted);
			return effects.ToArray();
		}
	}

	public EffectData[] EffectsUniqueAccepted
	{
		get {
			var effects = new List<EffectData>(effectsUniqueAccepted);
			if (genericItemData != null)
				effects.AddRange(genericItemData.EffectsUniqueAccepted);
			return effects.ToArray();
		}
	}

	public EffectData[] EffectsMandatory
	{
		get {
			var effects = new List<EffectData>(effectsMandatory);
			if (genericItemData != null)
				effects.AddRange(genericItemData.EffectsMandatory);
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

