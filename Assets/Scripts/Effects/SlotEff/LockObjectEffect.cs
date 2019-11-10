using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockObjectEffect : SlotEffect
{
    internal override void ApplyEffect(Slot slot)
    {
		var item = slot.GetItem();
		if (item == null)
			slot.GetItem().Root();
		else
			Debug.LogError("Try to root a non item slot");
	}
}
