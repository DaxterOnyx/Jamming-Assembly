using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public GameObject scrollingArea;
    public GameObject corridorBackground;
    public float initialSpeed;
    public int initialLife;
    public int initialAtk;
}
