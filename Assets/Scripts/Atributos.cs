using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Atributos : MonoBehaviour {

	private Text dinheiroText;
	private Text viewersText;
	private int viewers;
	private int rep;
	private int maxRep;
	public static int dinheiro;
	private int tick;
	public static int rating;
	public int delay; // delay em ticks
	// Use this for initialization
	void Start () {
		dinheiroText = GameObject.Find("Dinheiro").GetComponent<Text>();
		viewersText = GameObject.Find("Viewers").GetComponent<Text>();
		dinheiro = 0;
		rep = 0;
		delay = 0;
		maxRep = 0;
		viewers = 2;
		tick = 0;
		rating=60;
	}

	void CalculaViewers(){
		int hour = Relogio.data.Hour;
		viewers = Mathf.RoundToInt( Mathf.Sin(hour/1.91f) + 0.4f + Mathf.Log(viewers+1)) + 1 ;
		viewers += maxRep > rep ? -((maxRep-rep)*(maxRep-rep)) : Mathf.RoundToInt(rep*Mathf.Log(rep+1));
	}

	void CalcularRep(){

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
			if(delay > 0 ){
				delay--;
			}
			else{
				rating = Mathf.Max(0,rating-1);
				CalcularRep();
				CalculaViewers();
				AtualizaAtributos();
			}
		}
	}
}
