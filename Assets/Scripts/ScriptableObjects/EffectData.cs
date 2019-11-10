using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EffectData", menuName = "ScriptableObjects/EffectData", order = -10)]
public class EffectData : ScriptableObject
{
    public string displayName;
    public EffectName effectName;
    public Sprite icon;
    public float probability;
    public Effect.Karma karma;
    [SerializeField]
    public enum EffectName
    {
        Empty,
        BlockSlot,
        FreeSlot,
        LockObject,
        UnlockObject
    }
}
