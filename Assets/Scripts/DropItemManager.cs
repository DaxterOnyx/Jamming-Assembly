using System;
using System.Collections;
using System.Collections.Generic;
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
		var oldItem = slots[0].GetItem();
		slots[0].SetItem(item,false);
		item.SetSlot(Slot.CreateArray(slots[0]));
		item.Shrink();
		SetItem(0,oldItem);
	}

	private void SetItem(int index, Item item)
	{
		if (slots.Length <= index)
			return;

	}
}
