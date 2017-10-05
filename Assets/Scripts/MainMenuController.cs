using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : Singleton<MainMenuController> {

	public Text highScore;

	// Use this for initialization
	void Start () {
		HSFunction ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Play()
	{
		SceneManager.LoadScene (1);
	}


	void HSFunction()
	{
		highScore.text = PlayerPrefs.GetInt ("HighScore").ToString ();
	}

}
