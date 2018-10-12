using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommentText : MonoBehaviour {

	public string userName {
		get {
			return user.text;
		}
		set {
			user.text = value;
		}
	}
	public string textBody {
		get {
			return text.text;
		}
		set {
			text.text = value;
		}
	}

	private Text user;
	private Text text;

	// Use this for initialization
	void Awake () {
		Text[] textos = GetComponentsInChildren<Text> ();
		if (textos.Length != 2) {
			Debug.Log ("Prefab de comentário quebrado");
			return;
		}

		if (textos[0].text != "Anônimo") {
			Text aux = textos[0];
			textos [0] = textos [1];
			textos [1] = aux;
		}

		user = textos [0];
		text = textos [1];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
