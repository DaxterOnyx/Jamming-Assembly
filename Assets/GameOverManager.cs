using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
	public void ReLaunchGame()
	{
		SceneManager.LoadScene(1);
	}

	public void Menu()
	{
		SceneManager.LoadScene(0);
	}
}
