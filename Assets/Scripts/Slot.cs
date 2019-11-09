using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {
	public enum State
	{
		UNAVAILABLE = 0,
		USABLE = 1,
		TAKEN,
		LOCKED
	}

	/// <summary>
	/// [déconseillé] préféré SetState ou IsTaken
	/// </summary>
	public State state;
	public Sprite[] sprites; 
	private Vector2Int position;
	private Item item;
    public GameObject gridPrefab;
    private GameObject grid;
    
	internal void SetPosition(int x, int y)
	{
		position = new Vector2Int(x, y);
	}

	internal void SetState(State p_state)
	{
		this.state = p_state;

		GetComponent<SpriteRenderer>().sprite = sprites[(int)state];


    }

	internal void SetItem(Item p_item)
	{
		item = p_item;
		SetState(State.TAKEN);
	}

    internal Item GetItem()
    {
        return item;
    }

	internal bool IsTaken()
	{
		return state == State.TAKEN;
	}

	private void OnMouseEnter()
	{
		SelectionManager.Instance.SetCaseOver(this);
	}
	private void OnMouseOver()
	{
		print(InventoryManager.Instance.SlotPosition(SelectionManager.Instance.MouseWorldPosition,false));
	}
    internal void SpawnGrid()
    {
       grid = Instantiate (gridPrefab, transform);
    }
    internal void KillGrid()
    {
        if (grid != null)
        {
            Destroy(grid);
        }
    }
}
