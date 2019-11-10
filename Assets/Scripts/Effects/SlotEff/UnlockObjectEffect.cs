public class UnlockObjectEffect : SlotEffect
{
	internal override void ApplyEffect(Slot slot)
	{
		var item = slot.GetItem();
		if (item == null)
			slot.GetItem().Unlock();
		else
			slot.SetState(Slot.State.USABLE);
	}
}
