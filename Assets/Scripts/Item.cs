using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
	ItemData itemData;
	Slot[] slots;
	bool mini;
	internal void Lock()
	{

	}

	internal void Unlock()
	{

	}

	private void OnMouseEnter()
	{
		SelectionManager.Instance.SetItemOver(this);
	}
}
