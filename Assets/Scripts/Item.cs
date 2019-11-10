using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	public ItemData itemData;
	Slot[] slots;
	public Vector2Int size;
	public List<Effect> effectList;

    //TODO CEST MOCHE Ou pas 
    bool IsBig { get { return itemData.size != Vector2Int.one; } }
    bool isMini;
    private bool isDraging;

    /// <summary>
    /// Select a random number of random effect added to the item
    /// </summary>
    /// <param name="data">ItemData</param>
    public void Init(ItemData data)
    {
        int indice;
        EffectData effectData;
        List<Vector2Int> usedSlots = new List<Vector2Int>();
        effectList = new List<Effect>();
        itemData = data;
        size = itemData.size;
        int effectCount = 0;
        Effect temp;
        Vector2Int effectSlot;
        List<int> effectIndice = new List<int>();

		//Ajout des effets uniques dans la liste

		for (int i = 0; i < itemData.EffectsUniqueAccepted.Length; i++) {
			effectIndice.Add(i);
		}
		while (effectIndice.Count > 0) {
			indice = UnityEngine.Random.Range(0, effectIndice.Count);
			effectData = itemData.EffectsUniqueAccepted[effectIndice[indice]];
			effectIndice.Remove(effectIndice[indice]);

            if (effectData.probability < UnityEngine.Random.value && effectCount < itemData.maxEffects)
            {
                switch (effectData.effectName)
                {
                    case EffectData.EffectName.BlockSlot:
                        temp = gameObject.AddComponent<BlockSlotEffect>();
                        break;
                    case EffectData.EffectName.FreeSlot:
                        temp = gameObject.AddComponent<FreeSlotEffect>();
                        break;
                    case EffectData.EffectName.LockObject:
                        temp = gameObject.AddComponent<LockObjectEffect>();
                        break;
                    case EffectData.EffectName.UnlockObject:
                        temp = gameObject.AddComponent<UnlockObjectEffect>();
                        break;
                    default:
                        temp = null;
                        Debug.LogError("Error: This effect name is not known yet!");
                        break;
                }
                temp.icon = effectData.icon;
                if (temp is SlotEffect)
                {
                    do
                    {
                        effectSlot = new Vector2Int(UnityEngine.Random.Range(0, 6), UnityEngine.Random.Range(0, 6));
                    } while (usedSlots.Contains(effectSlot));
                    usedSlots.Add(effectSlot);
                    temp.slot = effectSlot;
                }
                effectList.Add(temp);
            }
        }
    }

	internal void Lock()
	{
		bool reset = false;
		Slot.State resetState = Slot.State.USABLE;
		foreach (var slot in slots) {
			if (!slot.IsBinded) {
				slot.SetState(Slot.State.LOCKED);
			} else {
				reset = true;
				resetState = slot.GetState();
			}
		}
		if(reset)
			foreach (var slot in slots) {
				slot.SetState(p_state: resetState);
			}
	}

	internal void Unlock()
	{
		bool reset = false;
		Slot.State resetState = Slot.State.USABLE;
		foreach (var slot in slots) {
			if (slot.IsBinded) {
				slot.SetState(Slot.State.USABLE);
			} else {
				reset = true;
				resetState = slot.GetState();
			}
		}
		if (reset)
			foreach (var slot in slots) {
				slot.SetState(p_state: resetState);
			}
	}

	internal void Root()
	{
		bool reset = false;
		Slot.State resetState = Slot.State.USABLE;
		foreach (var slot in slots) {
			if (!slot.IsBinded) {
				slot.SetState(Slot.State.ROOTED);
			} else {
				reset = true;
				resetState = slot.GetState();
			}
		}
		if (reset)
			foreach (var slot in slots) {
				slot.SetState(p_state: resetState);
			}
	}

	internal void UnRoot()
	{
		bool reset = false;
		Slot.State resetState = Slot.State.USABLE;
		foreach (var slot in slots) {
			if (slot.IsBinded) {
				slot.SetState(Slot.State.USABLE);
			} else {
				reset = true;
				resetState = slot.GetState();
			}
		}
		if (reset)
			foreach (var slot in slots) {
				slot.SetState(p_state: resetState);
			}
	}

	/// <summary>
	/// Prepare the item to follow the mouse
	/// </summary>
	/// <returns>if item can realy move</returns>
	internal bool SetInMouvement()
	{
		//Check if item can move
		var realy = true;
		foreach (var slot in slots) {
			if (slot.IsBinded)
				realy = false;
		}

        if (realy)
        {
            //if item is big resize at the real size
            if (IsBig)
                Rise();
            //disable collider to check the slot behind
            GetComponent<Collider2D>().enabled = false;

            isDraging = true;
        }

        return realy;
    }

    /// <summary>
    /// downgrade the size of the item, not definitive
    /// </summary>
    internal void Shrink()
    {
        isMini = true;
        GetComponent<SpriteRenderer>().sprite = itemData.miniSprite;
    }

    internal void EndDraggingInInventory(Slot[] newSlots)
    {
        isDraging = false;
        SetSlots(newSlots);
        GetComponent<Collider2D>().enabled = true;
        //TODO CALL EFFECT

    }

    internal void EndDraggingOnSpecialSlot(Slot slot)
    {
        isDraging = false;
        foreach (var t in slots)
        {
            t.RemoveItem();
        }
        slots = Slot.CreateArray(slot);
        slot.SetItem(this);

        RecalculPosition();
        GetComponent<Collider2D>().enabled = true;
    }

    /// <summary>
    /// Upgrade the size of the item, not definive
    /// </summary>
    internal void Rise()
    {
        isMini = false;
        GetComponent<SpriteRenderer>().sprite = itemData.realSprite;
    }

    /// <summary>
    /// overwrite the actual slots on the item will be
    /// </summary>
    /// <param name="newSlots">Usable Slot</param>
    internal void SetSlot(Slot newSlot)
    {
        SetSlots(Slot.CreateArray(newSlot));
    }

    /// <summary>
    /// overwrite the actual slots on the item will be
    /// </summary>
    /// <param name="newSlots">Array of usable slots</param>
    internal void SetSlots(Slot[] newSlots)
    {
        if (slots != null)
            foreach (var slot in slots)
            {
                slot.RemoveItem();
            }

        slots = newSlots;
        foreach (var slot in slots)
        {
            slot.SetItem(this);
        }
        RecalculPosition();
    }

    /// <summary>
    /// Redefine where the item must be with him slots
    /// </summary>
    private void RecalculPosition()
    {
        transform.DOMove(CenterPosition(), 0.1f);
    }

    /// <summary>
    /// Calcul the center of slots
    /// </summary>
    /// <returns>Average of each position of slots</returns>
    private Vector3 CenterPosition()
    {
        Vector3 position = new Vector2();
        foreach (var item in slots)
        {
            position += item.transform.position;
        }
        return position / slots.Length;
    }

    /// <summary>
    /// Reset the deplacement affected on the item, It come back at the origin slots
    /// </summary>
    internal void ResetMouvement()
    {
        isDraging = false;
        GetComponent<Collider2D>().enabled = true;
        RecalculPosition();
    }


    private void OnMouseEnter()
    {
        SelectionManager.Instance.SetItemOver(this);
        InfoBubble.Instance.Show(this);
    }

    private void OnMouseExit()
    {
        InfoBubble.Instance.Hide();
    }

    private void OnMouseDown()
    {
        SelectionManager.Instance.SelectItem(this);
    }

    private void OnMouseUp()
    {
        if (isDraging)
            SelectionManager.Instance.DropItem(this);
    }

}
