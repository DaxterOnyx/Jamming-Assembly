using System.Collections.Generic;
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
				Debug.LogError("Singleton DropItemManager not found");
			}

			return m_instance;
		}
	}


	public InventoryData inventoryData;
	float delta;
	private Slot[,] inventory;

	internal void Init()
	{
		delta = inventoryData.Gap + inventoryData.SlotSize;

		inventory = new Slot[inventoryData.Width, inventoryData.Heigth];
		for (int x = 0; x < inventoryData.Width; x++) {
			for (int y = 0; y < inventoryData.Heigth; y++) {
				Slot slot = CreateSlot(x, y, false);
				slot.SetState(Slot.State.UNAVAILABLE);
				inventory[x, y] = slot;
			}
		}

		foreach (var item in inventoryData.IsFree) {
			inventory[item.x, item.y].SetState(Slot.State.USABLE);
		}
	}

	internal void AddItemOnRandSlot(Item item)
	{
		Vector2Int size = item.size;
		var freeSpace = SearchEmptySpace(size);

		if (freeSpace.Length == 0) {
			GameManager.Instance.Lose();
			return;
		}

		var slotPos = freeSpace[UnityEngine.Random.Range(0, freeSpace.Length)];


		Slot[] slots = GetSlots(slotPos.x, slotPos.y, size);

		item.SetSlots(slots);
	}

	internal Slot[] GetSlots(int x, int y, Vector2Int size)
	{
		int width = size.x;
		int height = size.y;
		int nbSlot = width * height;

		Slot[] slots = new Slot[nbSlot];

		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {

				slots[i * (width - 1) + j] = GetSlot(x + i, y + j);
			}
		}

		return slots;
	}

	private Vector2Int[] SearchEmptySpace(Vector2Int size)
	{
		List<Vector2Int> list = new List<Vector2Int>();

		for (int x = 0; x < inventoryData.Width; x++) {
			for (int y = 0; y < inventoryData.Heigth; y++) {
				bool isOk = inventory[x, y].CanAcceptItem(size);
				if (isOk)
					list.Add(new Vector2Int(x, y));
			}
		}
		return list.ToArray();
	}



	private Slot CreateSlot(int x, int y, bool locked)
	{
		var slot = Instantiate(inventoryData.SlotPrefab, transform).GetComponent<Slot>();
		slot.transform.localPosition = SlotWorldPosition(x, y);
		slot.SetPosition(x, y);
		slot.SetState(locked ? Slot.State.UNAVAILABLE : Slot.State.USABLE);
		return slot;
	}

	internal Slot GetSlot(int x, int y)
	{
		if (x < 0 || y < 0 || x > inventoryData.Width || y > inventoryData.Heigth)
			return null;
		return inventory[x, y];
	}

	private Vector3 SlotWorldPosition(int x, int y)
	{
		return new Vector3(x * delta, y * delta, 0);
	}

	public Vector2Int SlotPosition(Vector2 worldPosition, bool isLocalPosition)
	{
		Vector2Int position;
		if (isLocalPosition) {
			position = new Vector2Int(Mathf.FloorToInt(worldPosition.x / delta), Mathf.FloorToInt(worldPosition.y / delta));
		} else {
			var tt = worldPosition - (Vector2)transform.position + new Vector2(delta / 2, delta / 2);
			//print(tt);
			position = SlotPosition(tt, true);
		}

		return position;
	}

	public void AddEffectOnSlot(int x, int y, SlotEffect effect)
	{
		Slot slot = GetSlot(x, y);
		effect.ApplyEffect(slot);
	}
}
