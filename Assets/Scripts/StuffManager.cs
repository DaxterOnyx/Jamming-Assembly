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
	public Slot ConcumableSlot2;
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
}
