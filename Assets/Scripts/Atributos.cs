using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Atributos : MonoBehaviour {

	private Text dinheiroText;
	private Text viewersText;
	private int viewers;
	public static int rep;
	private int maxRep;
	public static int dinheiro;
	private int tick;
	public static int rating; // aumenta quando faz um upgrade, e decai com o tempo
	public static int delay; // delay em ticks
	// Use this for initialization
	void Start () {
		//dinheiroText = GameObject.Find("Dinheiro").GetComponent<Text>();
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
		// Debug.Log("1: " + viewers);
		viewers = Mathf.RoundToInt( 3*Mathf.Sin(hour/1.91f) + 0.4f + Mathf.Log(viewers+1));
		// Debug.Log("2: " + viewers);
		viewers += maxRep > rep ? -((maxRep-rep)*(maxRep-rep)) : Mathf.RoundToInt(rep*Mathf.Log(rep+1));
		// Debug.Log("3: " + viewers + " " + Mathf.RoundToInt(rep*Mathf.Log(rep+1)) + " " + rep);
	}

	void CalcularRep(){
		rep += Mathf.RoundToInt(Mathf.Log(rating+1));
	}

	void AtualizaAtributos(){
		dinheiro += viewers;
		viewersText.text = viewers.ToString() +  " VIEWERS";
		//dinheiroText.text = "Dinheiro " + dinheiro;
	}

	void ChecarVitoria(){

	}

	public void Share(){
		// colocar delay, e se clicar demais, tirar viewrs e trigerrar comentario
		viewers++;
	}

	// Update is called once per frame
	void Update () {
		if(tick < Relogio.ticks){
			tick = Relogio.ticks;
			if(delay > 0 ){
				delay--;
				// alguma animacao aqui
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
