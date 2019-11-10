using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockObjectEffect : SlotEffect
{
    internal override void ApplyEffect(Slot slot)
    {
         slot.GetItem().Unlock();
    }
}
