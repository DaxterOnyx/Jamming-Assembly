using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockObject : SlotEffect
{
    internal override void ApplyEffect(Slot slot)
    {
        if(slot.state == Slot.State.TAKEN)
        {
            slot.GetItem().Lock();
        }
    }
}
