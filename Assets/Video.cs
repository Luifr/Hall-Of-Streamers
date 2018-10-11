using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Video : MonoBehaviour {

	bool paused = true;
	public Sprite pausedImage;
	public Sprite playImage;
	private Image image;

	// Use this for initialization
	void Start () {
		image = gameObject.GetComponent<Image>();
	}
	
	public void ChangeState(){
		paused = !paused;
		if(!paused){
			image.sprite = playImage;
		}
		else{
			image.sprite = pausedImage;
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
