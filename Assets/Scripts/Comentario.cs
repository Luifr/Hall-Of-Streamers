using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Comentario : MonoBehaviour {

	private List<UpgradeSoftware> equipment;
	private string[] nomes;
	private string[][] comentario;
	private string[] comentarioPositivo;

	// Use this for initialization
	void Start () {
		equipment = new List<UpgradeSoftware>();
		UpgradeSoftware[] u = GameObject.Find("Equipments").GetComponentsInChildren<UpgradeSoftware>();
		foreach(UpgradeSoftware t in u){
			if(t.id == Investimentos.Tipo.Camera || t.id == Investimentos.Tipo.Microfone || t.id == Investimentos.Tipo.SoftwareDeGravacao ){
				equipment.Add(t);				
			}
		}

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

	void Comentar(){
		string s;
		if(UnityEngine.Random.Range(0,100) > Atributos.rating){
			Atributos.rep-=UnityEngine.Random.Range(1,Mathf.RoundToInt(Mathf.Log(Atributos.rep+1)*Mathf.Log(Atributos.rep+1))+1);
			int i = getEquipmentToComment();
			s = comentario[i][ UnityEngine.Random.Range(0,comentario[i].Length)  ];
		}
		else{
			s = comentarioPositivo[UnityEngine.Random.Range(0,comentarioPositivo.Length)];
			string nome = nomes[ UnityEngine.Random.Range(1,nomes.Length) ];
			if(UnityEngine.Random.Range(1,100) > 70 ){
				nome += "_gamer";
			}
			if(UnityEngine.Random.Range(1,100) > 60 ){
				nome += UnityEngine.Random.Range(1,100000).ToString();
			}
		}
		// printar s como comentario
	}

	int getEquipmentToComment(){
		equipment.Sort(delegate(UpgradeSoftware u1, UpgradeSoftware u2){
			int j = (int)(u1.id) - (int)(u2.id);
			return j != 0 ? j : (u1.ultimoUpgrade - u2.ultimoUpgrade).Seconds; 
		});
		int i=0;
		while(UnityEngine.Random.Range(0,101) >= 80){
			i = Math.Max(i+1, equipment.Count-1 );
		}
		return (int)(equipment[i].id);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
