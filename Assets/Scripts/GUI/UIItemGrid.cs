using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemGrid : MonoBehaviour
{
    private static UIItemGrid m_instance;
    public static UIItemGrid Instance
    {
        get
        {
            if (m_instance == null)
                m_instance = FindObjectOfType<UIItemGrid>();
            if (m_instance == null)
            {
                Debug.LogError("Singleton UIItemGrid not found");

            }

            return m_instance;
        }
    }


    private RectTransform rect;
    private GridLayout grid;
    public UIGridData data;
    private GameObject[,] uiCellTab;
    private Vector2Int gridSize;
    
    internal void Init()
    {
        m_instance = this;
        rect = this.gameObject.GetComponent<RectTransform>();
        gridSize = new Vector2Int(7, 7);
        uiCellTab = new GameObject[7, 7];
    }
    internal void setGridSize(Vector2Int itemSize)
    {
        gridSize = itemSize + new Vector2Int(4, 4);
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                uiCellTab[x, y] = Instantiate(data.uiCell, transform);
            }
        }
        rect.sizeDelta = new Vector3(gridSize.x, gridSize.y) * (data.cellSize + data.distanceBetweenCell);
    }

    internal void RestartCell()
    {
        foreach (var item in uiCellTab)
        {
            Destroy(item);
        }
    }
}
