using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {


	// Use this for initialization
	public void CheckSave (Button button) {
		if(!File.Exists(Application.persistentDataPath + "/" + Saver.filename)){
			button.interactable = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Exit() {
		Application.Quit ();
	}

	public void LoadNewGame(GameObject warn){
		if(File.Exists(Application.persistentDataPath + "/" + Saver.filename)){
			warn.SetActive(true);
			return;
		}
		Saver.load = false;
		SceneManager.LoadScene ("SampleScene");
	}

	public void LoadNewGame(){
		Saver.load = false;
		File.Delete(Application.persistentDataPath + "/" + Saver.filename);
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
