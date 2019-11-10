using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EffectData", menuName = "ScriptableObjects/EffectData", order = -10)]
public class EffectData : ScriptableObject
{
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
    public string effectPath;

}
