using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
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
}
