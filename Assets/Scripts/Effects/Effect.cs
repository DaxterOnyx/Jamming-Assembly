using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : MonoBehaviour 
{
    public string effectName;
    public Sprite Icon;
    public int probability;
	public Karma karma;
	public enum Karma
	{
		GOOD,
		NEUTRAL,
		BAD
	}
}
