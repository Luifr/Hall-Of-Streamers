using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Atributos : MonoBehaviour {

	private List<Text> dinheiroText;
	private List<Text> dinheiroMenu;
	private Text viewersText;
	public int viewers;
	public static int rep;
	private int maxRep;
	public static float dinheiro;
	private int tick;
	public static int rating; // aumenta quando faz um upgrade, e decai com o tempo
	public static int delay; // delay em ticks
	// Use this for initialization
	void Start () {
		var gobj = Resources.FindObjectsOfTypeAll<Text>();
		dinheiroText = new List<Text>();
		dinheiroMenu = new List<Text>();
		foreach(Text o in gobj){
			if(o.gameObject.tag.Equals("dinheiro"))
				dinheiroText.Add( o.GetComponent<Text>() );
			else if(o.gameObject.tag.Equals("dinheiroMenu")){
				dinheiroMenu.Add( o );
			}
		}
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
		viewers = Mathf.Max(0,viewers);
	}

	void CalcularRep(){
		rep += Mathf.RoundToInt(Mathf.Log(rating+1));
	}

	public void AtualizaAtributos(){
		foreach(Text t in dinheiroText){
			t.text = "Vortex Jelly - Dinheiro R$ " + dinheiro;
		}
		foreach(Text t in dinheiroMenu){
			t.text = "R$ " + dinheiro;
		}
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
				dinheiro += viewers * 0.07f ;
				CalcularRep();
				CalculaViewers();
				AtualizaAtributos();
			}
		}
	}
}
