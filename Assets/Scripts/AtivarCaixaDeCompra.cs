using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtivarCaixaDeCompra : MonoBehaviour {

	private Button[] transforms;

	// Use this for initialization
	void Start () {
		GameObject g = GameObject.Find("CaixasDeCompra");
		if(g != null)
			transforms = g.GetComponentsInChildren<Button>(true);
	}
	
	public void SetBox(string s){
		if(transforms == null){
			GameObject g = GameObject.Find("CaixasDeCompra");
			transforms = g.GetComponentsInChildren<Button>(true);
		}
		foreach(Button t in transforms){
			if(t.gameObject.name.Equals(s)){
				t.gameObject.SetActive(true);
			}
			else{
				t.gameObject.SetActive(false);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
