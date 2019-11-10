using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeSlotEffect : SlotEffect
{
    internal override void ApplyEffect(Slot slot)
    {
        if(slot.IsUnvailable)
        {
            slot.SetState(Slot.State.USABLE);
        }
        if (slot.isLocked)
        {
            if (slot.GetItem() != null)
            {
                slot.GetItem().Unlock();
            }
            
            slot.SetState(Slot.State.USABLE);
        }
    }
}
