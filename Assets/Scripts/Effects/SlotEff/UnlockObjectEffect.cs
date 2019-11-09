using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockObjectEffect : SlotEffect
{
    internal override void ApplyEffect(Slot slot)
    {
        if (slot.state == Slot.State.LOCKED)
        {
            slot.GetItem().Unlock();
        }
    }
}
