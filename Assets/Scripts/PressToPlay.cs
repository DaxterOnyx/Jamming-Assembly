using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressToPlay : MonoBehaviour
{
	public string game;
    // Update is called once per frame
    void Update()
    {
		if (Input.anyKeyDown)
			SceneManager.LoadScene(game);
    }
}
