using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Atributos : MonoBehaviour {

	public float[] hourModifier = new float[] {.6f,.5f,.4f,.4f,.3f,.6f,.7f,.7f,.8f,.8f,.9f,1 ,.9f,1.2f,1.2f,1.4f,1.3f,1.2f,1f,.9f,.8f,.8f,.7f,.7f };
	private List<Text> dinheiroText;
	private List<Text> dinheiroMenu;
	private Text viewersText;
	public int viewers;
	public static int baseViewers;
	public static int rep;
	private int maxRep;
	public static float dinheiro;
	private int tick;
	public static int rating; // aumenta quando faz um upgrade, e decai com o tempo
	public static int delay; // delay em ticks
	public int shareClicks;
	private int dia = System.DateTime.Now.Day;
	private int boost = 0;
	public static DateTime delayFinish; // Tempo de finalização do FastForward
	public static bool fastForward;
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
		dinheiro = 15000;
		rep = 0;
		delayFinish = new DateTime ();
		fastForward = false;
		maxRep = 0;
		viewers = 7;
		baseViewers = 7;
		tick = 0;
		rating=60;
		AtualizaAtributos();
	}

	void CalculaBaseViewers(){
		if(( maxRep+1) / (rep+1) > 1.2f ){
			baseViewers -= Mathf.RoundToInt(  Mathf.Log(rep*rep*rep*rep)    );
		}
		else{
			baseViewers += Mathf.RoundToInt(  Mathf.Log(rep*rep)    );
		}
	}

	void CalculaViewers(){
		int hour = Relogio.data.Hour;
		viewers = Mathf.RoundToInt(baseViewers * hourModifier[hour]);
		//viewers += (maxRep+1)/(rep+1) > 1.15f ? -Mathf.RoundToInt( (viewers*.3f)) : Mathf.RoundToInt( Mathf.Log(rep+1)+1 );
		viewers = Mathf.Max(0,viewers);
	}

	void CalcularRep(){
		rep += Mathf.RoundToInt(Atributos.rating*Mathf.Log(rating+1));
		rep = Mathf.Max(0,rep);
		if(maxRep < rep){
			maxRep = rep;
		}
	}

	public void AtualizaAtributos(){
		foreach(Text t in dinheiroText){
			t.text = "Vortex Jelly - Dinheiro R$ " + dinheiro.ToString("F2");
		}
		foreach(Text t in dinheiroMenu){
			t.text = /*"rating: " + rating + "; max: " + maxRep + "; rep: " + rep +";*/ "R$ " + dinheiro.ToString("F2");
		}
		viewersText.text = viewers.ToString() +  " VIEWERS";
		//dinheiroText.text = "Dinheiro " + dinheiro;
	}

	void ChecarVitoria(){

	}

	public void Share(){
		// colocar delay, e se clicar demais, tirar viewrs e trigerrar comentario
		if(shareClicks++==0 && boost==0 )
			boost = 1;
		else if(shareClicks>=7){
			baseViewers-= Mathf.RoundToInt(Mathf.Log(shareClicks)/10);
			Chat.AddCommentToChat(Comentario.getRandName(),"Para de spamma!!!");
		}
	}

	// Update is called once per frame
	void Update () {
		if (delayFinish > Relogio.data) {
			fastForward = true;
		} 
		else {
			fastForward = false;
			if(tick < Relogio.ticks){
				tick = Relogio.ticks;
				if(boost == 1){
					baseViewers = Mathf.CeilToInt(baseViewers * 1.2f)+1;
					boost = -4;
				}
				else if(boost<0){
					boost++;
				}
				shareClicks = Mathf.FloorToInt( shareClicks*0.80f )-1 ;
				shareClicks=Mathf.Max(0,shareClicks);
				rating = Mathf.Max(0,rating-1);
				dinheiro += viewers * 0.03f ;
				CalcularRep();
				CalculaViewers();
				AtualizaAtributos();
			}
			if(dia < Relogio.data.Day){
				dia = Relogio.data.Day;
				CalculaBaseViewers();
			}
		}
	}
}
