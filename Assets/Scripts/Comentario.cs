using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Comentario : MonoBehaviour {

	private Investimentos[] equipment;
	public static string[] nomes;
	private string[][] comentario;
	private string[] comentarioPositivo;

	private int commentChance;
	private int tick;

	// Use this for initialization
	void Start () {
		equipment = GameObject.Find("Equipments").GetComponentsInChildren<Investimentos>();
		tick = Relogio.ticks;
		commentChance = 25;

		InicializarStrings ();
	}

	// Update is called once per frame
	void Update () {
		if (tick != Relogio.ticks && !Atributos.fastForward) {
			if (UnityEngine.Random.Range (0, 100) < commentChance)
				Comentar ();

			tick = Relogio.ticks;
		}
	}

	public static string getRandName(){
		string nome;
		nome = nomes[ UnityEngine.Random.Range(1,nomes.Length) ];
		if (UnityEngine.Random.Range (1, 100) > 85) {
			nome += "_gamer";
		}
		if (UnityEngine.Random.Range (1, 100) > 70) {
			nome += UnityEngine.Random.Range (1, 100000).ToString ();
		}

		return nome;
	}
	public void Comentar(){
		string s;
		if(UnityEngine.Random.Range(0,100) > Atributos.rating){
			Atributos.rep-= Mathf.RoundToInt(UnityEngine.Random.Range(.05f,.2f)*Atributos.rep);
			Atributos.rep = Mathf.Max(0,Atributos.rep);
			int i = getEquipmentToComment();
			s = comentario [i] [UnityEngine.Random.Range (0, comentario [i].Length)];
		}
		else{
			s = comentarioPositivo[UnityEngine.Random.Range(0,comentarioPositivo.Length)];
		}

		Chat.AddCommentToChat (getRandName(), s);
		// printar s como comentario
	}

	public int getEquipmentToComment(){
		Array.Sort(equipment,delegate(Investimentos u1, Investimentos u2){
			int j = (int)(u1.id) - (int)(u2.id);
			return j != 0 ? j : (u1.ultimoUpgrade - u2.ultimoUpgrade).Seconds; 
		});
		int i=0;
		while(UnityEngine.Random.Range(0,101) >= 80){
			i = Math.Min(i+1, equipment.Length-1 );
		}
		return (int)(equipment[i].id);
	}



	private void InicializarStrings() {
		comentario = new string[(int)Investimentos.Tipo.Size][];
		comentario [(int)Investimentos.Tipo.Camera] = new string[] {
			"sua camera e uma merda",
			"troca essa camera"
		};
		comentario [(int)Investimentos.Tipo.Microfone] = new string[] {
			"O microfone ta bosta"
		};
		comentario [(int)Investimentos.Tipo.SoftwareDeGravacao] = new string[] {
			"Essa stream ta toda bugada",
			"Essa stream tem menos fps que o pc da xuxa"
		};

		comentarioPositivo = new string[] {
			"Esse aí é fera, heim meu",
			"Oloco bixo!",
			"Quem sabe faz ao vivo",
			"Tu é o bixão mesmo",
			"Bom trabalhoooo"
		};

		nomes = new String [] {
			"chickleslimy",
			"slimycuckoo",
			"andinfect",
			"slimycheeked",
			"stanhamslimy",
			"popperinfect",
			"infectcockney",
			"slimyasprin",
			"slimymiced",
			"freeslimy",
			"infectcastic",
			"slimygratis",
			"infectking",
			"macaronslimy",
			"slimyfaculae",
			"jiggaslimy",
			"slimyscornful",
			"canoeslimy",
			"hondoslimy",
			"jickinginfect",
			"slimyblue",
			"slimymistassini",
			"failingslimy",
			"milveyinfect",
			"radishinfect",
			"infectbass",
			"slimytheorem",
			"infectpankey",
			"infectsubtitles",
			"infectdemurrage",
			"fileslimy",
			"arroweslimy",
			"slimystagg",
			"infectpork",
			"infectmonitor",
			"babiesslimy",
			"kestrelslimy",
			"apacheslimy",
			"infectbanana",
			"foofslimy",
			"slimywaist",
			"infectsquod",
			"mediumslimy",
			"ofslimy",
			"infectskiing",
			"slimydeather",
			"oppositioninfect",
			"feetyinfect",
			"stoatinfect",
			"infectahead",
			"slimywax",
			"pishslimy",
			"slimygrapnel",
			"gradingslimy",
			"trentonslimy",
			"shareslimy",
			"windinginfect",
			"expeditedsslinfect",
			"infectscitch",
			"disneyinfect",
			"waldenslimy",
			"fileslimy",
			"biopsyslimy",
			"infectgreaseproof",
			"AloneChilled",
			"Apenguinte",
			"AprilPlatinum",
			"BuggyCandy",
			"Chasetson",
			"CozyIan",
			"Eventspart",
			"Fallstone",
			"Felinetlog",
			"Giandatr",
			"Healerte",
			"Hosionst"
		};
	}
}
