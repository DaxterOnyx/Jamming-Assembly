using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager m_instance;
	public static GameManager Instance
	{
		get {
			if (m_instance == null)
				m_instance = FindObjectOfType<GameManager>();
			if (m_instance == null) {
				GameObject newInstance = Instantiate(new GameObject());
				newInstance.name = "GameManager (Singleton)";
				m_instance = newInstance.AddComponent<GameManager>();
			}

			return m_instance;
		}
	}

	public InfoBubble infoBubbleInstance;

	void Start()
	{
		InventoryManager.Instance.Init();
		SelectionManager.Instance.Init();
		DropItemManager.Instance.Init();
		infoBubbleInstance.Init();
	}
}
