using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public int startLevel;

	public void Play ()
	{
		Debug.Log("Play");
		SceneManager.LoadScene(startLevel);
	}

	public void Quit ()
	{
		Debug.Log("Quit");
		Application.Quit();
	}
}