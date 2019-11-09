using System;
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
		//if (inventoryData == null)
		//	inventoryData = InventoryData.CreateInstance<InventoryData>();

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
		SearchEmptySpace(item.size);
	}

	private void SearchEmptySpace(Vector2Int size)
	{
		throw new NotImplementedException();
	}

	private Slot CreateSlot(int x, int y, bool locked)
	{
		//TODO add initial free and locked Slot
		var slot = Instantiate(inventoryData.SlotPrefab, transform).GetComponent<Slot>();
		slot.transform.localPosition = SlotWorldPosition(x, y);
		slot.SetPosition(x, y);
		slot.SetState(locked ? Slot.State.UNAVAILABLE : Slot.State.USABLE);
		return slot;
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
			var tt = worldPosition - (Vector2)transform.position + new Vector2(delta/2, delta / 2);
			//print(tt);
			position =	SlotPosition(tt, true);
		}

		return position;
	}

	public void AddEffectOnSlot(int x, int y, SlotEffect effect)
	{
		if (x < 0 || y < 0 || x > inventoryData.Width || y > inventoryData.Heigth)
			return;

		effect.ApplyEffect(inventory[x, y]);
	}
}
