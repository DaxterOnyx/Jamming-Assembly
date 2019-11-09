using System;
using UnityEngine;

public class Item : MonoBehaviour
{
	ItemData itemData;
	Slot[] slots;
	bool mini;
	internal void Lock()
	{
        foreach (var item in slots)
        {
            item.SetState(Slot.State.LOCKED);

        }
	}

	internal void Unlock()
	{
        foreach (var item in slots)
        {
            item.SetState(Slot.State.TAKEN);
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
		var realy = slots[0].isBinded();
		if (realy)
			mini = false;
		return realy;
	}

	private void OnMouseUp()
	{
		SelectionManager.Instance.DropItem(this);
	}

	internal void SetSlot(Slot newSlot)
	{
		transform.position = newSlot.transform.position;
		//TODO CALL EFFECT
	}
}
