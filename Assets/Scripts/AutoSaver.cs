using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoSaver : MonoBehaviour {

	public Toggle autoSave;
	public Saver saver;

	private const float autosaveDelay = 20;
	private float autosaveTime;

	// Use this for initialization
	void Start () {
		//autoSave = GetComponentInChildren<Toggle> ();
		autosaveTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		// Autosaving....
		if (autoSave.isOn) {
			if (autosaveTime >= autosaveDelay) {
				Debug.Log ("Auto saving!");
				autosaveTime = 0;
				saver.Save ();
			}
			autosaveTime += Time.deltaTime;
		}
	}
}
