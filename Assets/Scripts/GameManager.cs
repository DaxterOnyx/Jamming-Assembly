using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public UIItemGrid itemGridInstance;
	public string gameover;

	void Start()
	{
        itemGridInstance.Init();
		InventoryManager.Instance.Init();
		SelectionManager.Instance.Init();
		DropItemManager.Instance.Init();
		infoBubbleInstance.Init();
		StuffManager.Instance.Init();
	}

	internal void Lose()
	{
		SceneManager.LoadScene(gameover);
	}
}
