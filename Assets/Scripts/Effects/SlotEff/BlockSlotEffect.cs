using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSlotEffect : SlotEffect
{
    internal override void ApplyEffect(Slot slot)
    {
		var item = slot.GetItem();
		if (item == null)
			item.Lock();
		else
			slot.SetState(Slot.State.LOCKED);
	}
}
