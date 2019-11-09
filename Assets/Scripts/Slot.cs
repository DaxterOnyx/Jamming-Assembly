using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {
	public enum State
	{
		LOCKED,
		FREE,
		OCCUPIED,
		BINDED
	}

	public State state;

	private Vector2Int position;

	internal void SetPosition(int x, int y)
	{
		position = new Vector2Int(x, y);
	}
}
