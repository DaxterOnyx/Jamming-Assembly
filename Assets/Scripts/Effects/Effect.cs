using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Effect : MonoBehaviour 
{
    public Vector2Int slot;
    public string effectName;
    public Sprite icon;
    public float probability;
	public Karma karma;
	public enum Karma
	{
		GOOD,
		NEUTRAL,
		BAD
	}
}
