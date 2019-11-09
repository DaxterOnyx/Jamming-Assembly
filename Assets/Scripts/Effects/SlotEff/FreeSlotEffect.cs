using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeSlotEffect : SlotEffect
{
    internal override void ApplyEffect(Slot slot)
    {
        if(slot.state == Slot.State.UNAVAILABLE)
        {
            slot.SetState(Slot.State.USABLE);
        }
    }
}
