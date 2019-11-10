using UnityEngine;

public class TutoManager : MonoBehaviour
{
	int index = 0;
	bool stop = false;
	public GameObject[] gameObjects;
	private void Start()
	{
		Time.timeScale = 0;
		foreach (var item in gameObjects) {
			item.SetActive(false);
		}
		gameObjects[index].SetActive(true);
	}

	void Update()
	{
		if (stop)
			return;
		if (Input.anyKeyDown && index < gameObjects.Length) {
			gameObjects[index++].SetActive(false);
			if (index < gameObjects.Length)
				gameObjects[index].SetActive(true);
		}
		if (index == gameObjects.Length) {
			Time.timeScale = 1;

			stop = true;
		}
	}
}
