using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UIGridData", menuName = "ScriptableObjects/UIGridData")]
public class UIGridData : ScriptableObject
{
    public GameObject uiCell;
    public float distanceBetweenCell;
    public float cellSize;
}
