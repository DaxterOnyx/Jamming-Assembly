using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItemGrid : MonoBehaviour
{
    public UIGridData data;
    private GameObject[,] uiCellTab;
    private Vector2Int gridSize;
    internal void setGridSize(Vector2Int itemSize)
    {
        
    }

    internal void DestroyCells()
    {
        foreach (var item in uiCellTab)
        {
        }
    }
}
