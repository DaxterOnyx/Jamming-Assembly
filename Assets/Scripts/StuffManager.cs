using DG.Tweening;
using UnityEngine;

public class StuffManager : MonoBehaviour
{
	private static StuffManager m_instance;
	public static StuffManager Instance
	{
		get {
			if (m_instance == null)
				m_instance = FindObjectOfType<StuffManager>();
			if (m_instance == null) {
				Debug.LogError("Singleton StuffManager not found");
			}

			return m_instance;
		}
	}


	public Slot HelmetSlot;
	public Slot ChestplateSlot;
	public Slot WeaponSlot;
	public Slot ShieldSlot;
	public Slot AccesoryLeftSlot;
	public Slot AccesoryRightSlot;
	public Slot RightBootSlot;
	public Slot LeftBootSlot;
	public Slot ConsumableSlot2;
	public Slot ConsumableSlot;
	public Slot BinSlot;

	internal void Init()
	{
	}

	private void Update()
	{
		var deleteItem = BinSlot.GetItem();
		if (deleteItem != null) {
			BinSlot.RemoveItem();
			var deletedGameObject = deleteItem.gameObject;
			deleteItem.transform.DOMove(deleteItem.transform.position + new Vector3(0, -100f, 0), 0.5f); ;
			Destroy(deletedGameObject, 1);
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="type"></param>
	/// <param name="index"> 0 => Left, 1 => Right</param>
	/// <returns></returns>
	internal Slot GetSlot(ItemData.Type type, int index = 0)
	{
		switch (type) {
			case ItemData.Type.Undefinded:
				Debug.LogError("Undefined type for one item");
				return null;
			case ItemData.Type.Helmet:
				return HelmetSlot;
			case ItemData.Type.Accesory:
				if (index == 0)
					return AccesoryLeftSlot;
				else
					return AccesoryRightSlot;
			case ItemData.Type.Weapon:
				return WeaponSlot;
			case ItemData.Type.Shield:
				return ShieldSlot;
			case ItemData.Type.Boot:
				if (index == 0)
					return LeftBootSlot;
				else
					return RightBootSlot;
			case ItemData.Type.Consumable:
				if (index == 0)
					return ConsumableSlot;
				else
					return ConsumableSlot2;
			default:
				return null;
		}
	}
}