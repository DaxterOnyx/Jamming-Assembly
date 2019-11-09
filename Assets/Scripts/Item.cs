using DG.Tweening;
using System;
using UnityEngine;

public class Item : MonoBehaviour
{
	public ItemData itemData;
	Slot[] slots;
	public Vector2Int size; 

	//TODO CEST MOCHE Ou pas 
	bool IsBig { get { return itemData.size != Vector2Int.one; } }
	bool isMini;

	public void Init()
	{
		size = itemData.size;
		//TODO CHOOSE EFFECT IN TAB OF ITEM DATA
	}

	internal void Lock()
	{
        foreach (var slot in slots)
        {
            slot.SetState(Slot.State.LOCKED);
            slot.SpawnGrid();
        }
	}

	internal void Unlock()
	{
        foreach (var slot in slots)
        {
            slot.SetState(Slot.State.TAKEN);
            slot.KillGrid();
        }
    }


	/// <summary>
	/// Prepare the item to follow the mouse
	/// </summary>
	/// <returns>if item can realy move</returns>
	internal bool SetInMouvement()
	{
		//Check if item can move
		var realy = true;
		foreach (var slot in slots) {
			if (slot.isBinded)
				realy = false;
		}

		if (realy) {
			//if item is big resize at the real size
			if (IsBig)
				Rise();
			//disable collider to check the slot behind
			GetComponent<Collider2D>().enabled = false;
		}
		
		return realy;
	}

	/// <summary>
	/// downgrade the size of the item, not definitive
	/// </summary>
	internal void Shrink()
	{
		isMini = true;
		GetComponent<SpriteRenderer>().sprite = itemData.miniSprite;
	}

	/// <summary>
	/// Upgrade the size of the item, not definive
	/// </summary>
	internal void Rise()
	{
		isMini = false;
		GetComponent<SpriteRenderer>().sprite = itemData.realSprite;
	}


	/// <summary>
	/// overwrite the actual slots on the item will be
	/// </summary>
	/// <param name="newSlots">Usable Slot</param>
	internal void SetSlot(Slot newSlot)
	{
		SetSlots(Slot.CreateArray(newSlot));
	}

	/// <summary>
	/// overwrite the actual slots on the item will be
	/// </summary>
	/// <param name="newSlots">Array of usable slots</param>
	internal void SetSlots(Slot[] newSlots)
	{
		slots = newSlots;
		foreach (var slot in slots) {
			slot.SetItem(this,true);
		}
		GetComponent<Collider2D>().enabled = true;
		RecalculPosition();
		//TODO CALL EFFECT
	}

	/// <summary>
	/// Redefine where the item must be with him slots
	/// </summary>
	private void RecalculPosition()
	{
		transform.DOMove(CenterPosition(), 0.1f);
	}

	/// <summary>
	/// Calcul the center of slots
	/// </summary>
	/// <returns>Average of each position of slots</returns>
	private Vector3 CenterPosition()
	{
		Vector3 position = new Vector2();
		foreach (var item in slots) {
			position += item.transform.position;
		}
		return position / slots.Length;
	}

	/// <summary>
	/// Reset the deplacement affected on the item, It come back at the origin slots
	/// </summary>
	internal void ResetMouvement()
	{
		SetSlots(slots);
	}


	private void OnMouseEnter()
	{
		SelectionManager.Instance.SetItemOver(this);
	}

	private void OnMouseDown()
	{
		SelectionManager.Instance.SelectItem(this);
	}

	private void OnMouseUp()
	{
		SelectionManager.Instance.DropItem(this);
	}
	
}
