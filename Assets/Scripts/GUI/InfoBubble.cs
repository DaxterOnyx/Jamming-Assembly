using UnityEngine;
using UnityEngine.UI;

public class InfoBubble : MonoBehaviour
{
    private static InfoBubble m_instance;
    public static InfoBubble Instance
    {
        get
        {
            if (m_instance == null)
                m_instance = FindObjectOfType<InfoBubble>();
            if (m_instance == null)
            {
                Debug.LogError("Singleton InfoBubble not found");

            }

            return m_instance;
        }
    }

    public NameList nameList;
    private RectTransform rect;
    public Vector2 screenSize;
    public Vector3 gapMouseBubble;

    internal void Init()
    {
        rect = this.GetComponent<RectTransform>();
        m_instance = this;
    }

    void Update()
    {
        UpdatePosition();
        ChangePivot();
    }

    private void UpdatePosition()
    {
        transform.position = Input.mousePosition + gapMouseBubble;
    }

    private void ChangePivot()
    {
        float yPositionMax = rect.position.y + rect.sizeDelta.y;
        float yPositionMin = rect.position.y - rect.sizeDelta.y;
        float xPositionMax = rect.position.x + rect.sizeDelta.x;
        float xPositionMin = rect.position.x - rect.sizeDelta.x;
        if (yPositionMax> screenSize.y)
        {
            rect.pivot = new Vector2(rect.pivot.x, 1);
        }
        else if (yPositionMin < 0)
        {
            rect.pivot = new Vector2(rect.pivot.x, 0);
        }

        if (xPositionMax > screenSize.x)
        {
            rect.pivot = new Vector2(1 , rect.pivot.y);
        }
        else if (xPositionMin <0)
        {
            rect.pivot = new Vector2(0, rect.pivot.y);
        }
    }

    public void Show(Item item)
    {
        UpdatePosition();
        GetComponentInChildren<UIItemGrid>()?.SetGrid(item);
        GetComponentInChildren<IconList>()?.Fill(item);
        nameList.Fill(item);
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        GetComponentInChildren<UIItemGrid>()?.RestartCell();
        GetComponentInChildren<IconList>()?.Empty();
        nameList.Empty();
    }


}
