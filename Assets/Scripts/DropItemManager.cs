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
				Debug.LogError("Singleton DropItemManager not found");
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
		Add(0, item);
	}

	private void SetItem(int index, Item item)
	{
		var oldItem = slots[index].GetItem();
		if (oldItem != null)
			if (index >= slots.Length) {
				InventoryManager.Instance.AddItemOnRandSlot(item);
			} else {
				item.SetSlot(slots[index]);
				item.Shrink();
				SetItem(index + 1, oldItem);
			}
	}

	void Add(int i, Item item)
	{
		if (item != null) {
			if (i >= slots.Length)
				InventoryManager.Instance.AddItemOnRandSlot(item);
			else {

				Add(i + 1, slots[i].GetItem());
				item.SetSlot(slots[i]);
				item.Shrink();
			}
		}
	}
}


