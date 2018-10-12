using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Exit() {
		Application.Quit ();
	}

	public void LoadNewGame(){
		Saver.load = false;
		SceneManager.LoadScene ("SampleScene");
	}

	public void LoadGame(){
		Saver.load = true;
		SceneManager.LoadScene ("SampleScene");
	}

	public void LoadScene(string name) {
		SceneManager.LoadScene (name);
	}

}
