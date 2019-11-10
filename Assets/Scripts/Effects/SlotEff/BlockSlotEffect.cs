public class BlockSlotEffect : SlotEffect
{
	internal override void ApplyEffect(Slot slot)
	{
		var item = slot.GetItem();
		if (item != null)
			item.Lock();
		else
			slot.SetState(Slot.State.LOCKED);
	}
}
