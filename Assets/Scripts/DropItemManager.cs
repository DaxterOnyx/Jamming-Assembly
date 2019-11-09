using UnityEngine;

public class DropItemManager : MonoBehaviour
{
	private static DropItemManager m_instance;
	public static DropItemManager Instance
	{
		get {
			if (m_instance == null)
				m_instance = FindObjectOfType<DropItemManager>();
			if (m_instance == null) {
				GameObject newInstance = Instantiate(new GameObject());
				newInstance.name = "DropItemManager (Singleton)";
				m_instance = newInstance.AddComponent<DropItemManager>();
			}

			return m_instance;
		}
	}

	public Slot[] slots;

	public void Init()
	{

	}

	public void AddItem(Item item)
	{
		SetItem(0, item);
	}

	private void SetItem(int index, Item item)
	{
		if (slots.Length <= index) {
			InventoryManager.Instance.AddItemOnRandSlot(item);
		} else {
			var oldItem = slots[index].GetItem();
			slots[index].SetItem(item, false);
			item.SetSlot(Slot.CreateArray(slots[index]));
			item.Shrink();
			if (oldItem != null)
				SetItem(index + 1, oldItem);
		}
	}
}
