using DG.Tweening;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

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

        for (int i = 0; i < itemData.EffectsUniqueAccepted.Length; i++)
        {
            effectIndice.Add(i);
        }
        while (effectIndice.Count > 0)
        {
            indice = UnityEngine.Random.Range(0, effectIndice.Count);
            effectData = itemData.EffectsUniqueAccepted[effectIndice[indice]];
            effectIndice.Remove(effectIndice[indice]);

            if (effectData.probability < UnityEngine.Random.value && effectCount < itemData.maxEffects)
            {
                temp = ;
                temp.probability = effectData.probability;
                temp.icon = effectData.icon;
                temp.effectName = effectData.effectName;
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
		foreach (var slot in slots) {
			//TODO variable change
			//slot.SetState(Slot.State.LOCKED);
			slot.SpawnGrid();
		}
	}

	internal void Unlock()
	{
		foreach (var slot in slots) {
			//TODO variable change
			//slot.SetState(Slot.State.TAKEN);
			slot.KillGrid();
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

		if (realy) {
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
			foreach (var slot in slots) {
				slot.RemoveItem();
			}

		slots = newSlots;
		foreach (var slot in slots) {
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
		foreach (var item in slots) {
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
