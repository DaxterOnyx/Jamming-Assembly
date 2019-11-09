using DG.Tweening;
using System;
using UnityEngine;

public class Item : MonoBehaviour
{
	public ItemData itemData;
	Slot[] slots;
	//TODO CEST MOCHE
	bool IsBig { get { return itemData.size != Vector2Int.one; } }
	bool isMini;
	internal void Lock()
	{
        foreach (var item in slots)
        {
            item.SetState(Slot.State.LOCKED);
            item.SpawnGrid();

        }
	}

	internal void Unlock()
	{
        foreach (var item in slots)
        {
            item.SetState(Slot.State.TAKEN);
            item.KillGrid();
        }
    }

	private void OnMouseEnter()
	{
		SelectionManager.Instance.SetItemOver(this);
	}

	private void OnMouseDown()
	{
		SelectionManager.Instance.SelectItem(this);
	}

	internal bool SetInMouvement()
	{
		var realy = true;
		//var realy = slots[0].isBinded();
		if (realy) {
			if (IsBig)
				Rise();
			GetComponent<Collider2D>().enabled = false;
			isMini = false;
		}
		return realy;
	}

	internal void Shrink()
	{
		isMini = true;
		GetComponent<SpriteRenderer>().sprite = itemData.miniSprite;
	}

	internal void Rise()
	{
		isMini = false;
		GetComponent<SpriteRenderer>().sprite = itemData.realSprite;
	}

	private void OnMouseUp()
	{
		SelectionManager.Instance.DropItem(this);
	}

	internal void SetSlot(Slot[] newSlots)
	{
		slots = newSlots;
		foreach (var slot in slots) {
			slot.SetItem(this,true);
		}
		GetComponent<Collider2D>().enabled = true;
		RecalculPosition();

		//transform.position = newSlot.transform.position;
		//TODO CALL EFFECT
	}

	private void RecalculPosition()
	{
		transform.DOMove(CenterPosition(), 0.1f);
	}

	private Vector3 CenterPosition()
	{
		Vector3 position = new Vector2();
		foreach (var item in slots) {
			position += item.transform.position;
		}
		return position / slots.Length;
	}

	internal void ResetMouvement()
	{
		SetSlot(slots);
	}
}
