using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData")]
public class PlayerData : ScriptableObject
{
    //TODO ajouter un système de spawn des items
    public GameObject testItem;
    //TODO enlever l'item de test
    public GameObject scrollingAreaItems;
    public GameObject scrollingAreaForeground;
    public GameObject scrollingAreaBackground;
    public GameObject corridorItem;
    public float initialSpeed;
    public int initialLife;
    public int initialAtk;
}
