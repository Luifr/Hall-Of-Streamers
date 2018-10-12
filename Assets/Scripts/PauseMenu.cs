using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public Image bgImg;
	public RectTransform painel;
	public Vector3 posInicial = new Vector3 (-250, 0, 0);
	public bool isPaused;

	private static bool lerping;
	private static float timeAux;
	private static float t;
	private static Color col;

	// Use this for initialization
	void Awake () {
		//posPainel = 
		timeAux = 0;
		col = bgImg.color;
	}
	
	// Update is called once per frame
	void Update () {

	//	Debug.Log ("Lerping: " + lerping);
		if (lerping) {
			timeAux += 2 * Time.deltaTime;
			t = Mathf.Min (timeAux, 1);
			//Debug.Log ("T = " + t);
			painel.anchoredPosition = (Vector2) Vector3.Lerp (posInicial, Vector3.zero, t);
			bgImg.color = new Color (col.r, col.g, col.b, col.a*t);

			if (timeAux >= 1) {
				lerping = false;
				timeAux = 0;
				Time.timeScale = 0;
				GetComponentInChildren<Button> ().interactable = true;
			}
		}
	}

	public void PauseGame() {
		Debug.Log ("pausing game...");
		if (!isPaused) {
			lerping = true;
			gameObject.SetActive (true);
			GetComponentInChildren<Button> ().interactable = false;
			isPaused = true;
			painel.anchoredPosition = (Vector2)posInicial;
		}
	}

	public void Unpause() {
		Time.timeScale = 1;
		isPaused = false;
		gameObject.SetActive (false);
	}

}
