using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Atributos : MonoBehaviour {

	private Text dinheiroText;
	private Text viewersText;
	private int viewers;
	private int rep;
	private int dinheiro;
	private int tick;


	// Use this for initialization
	void Start () {
		dinheiroText = GameObject.Find("Dinheiro").GetComponent<Text>();
		viewersText = GameObject.Find("Viewers").GetComponent<Text>();
		dinheiro = 0;
		rep = 0;
		viewers = 2;
		tick = 0;
	}

	void CalculaViewers(){
		viewers+= Random.Range(-1,2);
		viewers = Mathf.Max(0,viewers);
	}

	void AtualizaAtributos(){
		dinheiro += viewers;
		viewersText.text = "Viewers " + viewers;
		dinheiroText.text = "Dinheiro " + dinheiro;
	}

	void ChecarVitoria(){

	}

	// Update is called once per frame
	void Update () {
		if(tick < Relogio.ticks){
			tick = Relogio.ticks;
			CalculaViewers();
			AtualizaAtributos();
		}
	}
}
