using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

	//TODO RESET VALUE
	public void ReLaunchGame()
	{
		SceneManager.LoadScene(0);
	}

	public void Menu()
	{
		SceneManager.LoadScene(0);
	}
}
