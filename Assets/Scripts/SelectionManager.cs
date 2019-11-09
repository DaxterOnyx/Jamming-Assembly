using System;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
	private static SelectionManager m_instance;
	public static SelectionManager Instance
	{
		get {
			if (m_instance == null)
				m_instance = FindObjectOfType<SelectionManager>();
			if (m_instance == null) {
				GameObject newInstance = Instantiate(new GameObject());
				newInstance.name = "SelectionManager (Singleton)";
				m_instance = newInstance.AddComponent<SelectionManager>();
			}

			return m_instance;
		}
	}

	private new Camera camera;
	private Slot currentCaseOver;

	private void Start()
	{
		camera = FindObjectOfType<Camera>();
	}

	public Vector2 MouseWorldPosition { get { return camera.ScreenToWorldPoint(Input.mousePosition); } }

	internal void SetCaseOver(Slot slot)
	{
		currentCaseOver = slot;
	}
}
