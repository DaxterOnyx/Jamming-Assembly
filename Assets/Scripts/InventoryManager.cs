using UnityEngine;

public class InventoryManager : MonoBehaviour
{
	private static InventoryManager m_instance;
	public static InventoryManager Instance
	{
		get {
			if (m_instance == null)
				m_instance = FindObjectOfType<InventoryManager>();
			if (m_instance == null) {
				GameObject newInstance = Instantiate(new GameObject());
				newInstance.name = "InventoryManager (Singleton)";
				m_instance = newInstance.AddComponent<InventoryManager>();
			}

			return m_instance;
		}
	}


	public InventoryData inventoryData;

	private Slot[,] inventory;

	internal void Init()
	{
		if (inventoryData == null)
			inventoryData = InventoryData.CreateInstance<InventoryData>();

		inventory = new Slot[inventoryData.Width, inventoryData.Heigth];
		for (int x = 0; x < inventoryData.Width; x++) {
			for (int y = 0; y < inventoryData.Heigth; y++) {
				Slot slot = CreateSlot(x, y, false);
				inventory[x, y] = slot;
			}
		}
	}

	private Slot CreateSlot(int x, int y, bool locked)
	{
		//TODO add initial free and locked Slot
		var slot = Instantiate(inventoryData.SlotPrefab, SlotWorldPosition(x, y), Quaternion.identity, transform).GetComponent<Slot>();
		slot.SetPosition(x, y);
		slot.SetState(locked ? Slot.State.LOCKED:Slot.State.FREE);
		return slot;
	}

	private static Vector3 SlotWorldPosition(int x, int y)
	{
		//TODO
		return new Vector3(x, y, 0);
	}

	public void AddEffectOnSlot(int x,int y, SlotEffect effect)
	{
		if (x < 0 || y < 0 || x > inventoryData.Width || y > inventoryData.Heigth)
			return;

		effect.ApplyEffect(inventory[x, y]);
	}
}
