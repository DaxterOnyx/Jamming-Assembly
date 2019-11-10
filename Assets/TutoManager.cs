using UnityEngine;

public class TutoManager : MonoBehaviour
{
	int index = 0;
	public GameObject[] gameObjects;
	void Update()
	{
		if (Input.anyKeyDown && index < gameObjects.Length) {
			gameObjects[index++].SetActive(false);
			if (index < gameObjects.Length)
				gameObjects[index].SetActive(true);
		}
	}
}
