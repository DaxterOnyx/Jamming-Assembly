using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBubble : MonoBehaviour
{
	private static InfoBubble m_instance;
	public static InfoBubble Instance
	{
		get {
			if (m_instance == null)
				m_instance = FindObjectOfType<InfoBubble>();
			if (m_instance == null) {
				Debug.LogError("Singleton InfoBubble not found");

			}

			return m_instance;
		}
	}

	public Vector3 gapMouseBubble;

	internal void Init()
	{
		m_instance = this;
	}

	void Update()
    {
		UpdatePosition();
    }

	private void UpdatePosition()
	{
		transform.position = Input.mousePosition + gapMouseBubble;
	}

	public void Show(Item item)
	{
		UpdatePosition();
        //TODO Show Data
        GetComponentInChildren<UIItemGrid>()?.setGridSize(item.size);
		gameObject.SetActive(true);
	}

	public void Hide()
	{
		gameObject.SetActive(false);
        GetComponentInChildren<UIItemGrid>()?.RestartCell();
    }

	
}
