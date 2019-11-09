using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {
	public enum State
	{
		LOCKED = 0,
		FREE = 1,
		TAKEN,
		BINDED
	}

	/// <summary>
	/// [déconseillé] préféré SetState ou IsTaken
	/// </summary>
	public State state;
	public Material[] materials; 
	private Vector2Int position;
	private Item item;

	internal void SetPosition(int x, int y)
	{
		position = new Vector2Int(x, y);
	}

	internal void SetState(State p_state)
	{
		this.state = p_state;

		GetComponent<Renderer>().material = materials[(int)state];
	}

	internal void SetItem(Item p_item)
	{
		item = p_item;
		SetState(State.TAKEN);
	}

	internal bool IsTaken()
	{
		return state == State.TAKEN;
	}
}
