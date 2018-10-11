using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Comentario : MonoBehaviour {

	private List<Upgrade> equipment;
	private string[] nomes;
	private string[][] comentario;

	// Use this for initialization
	void Start () {
		equipment = new List<Upgrade>();
		Upgrade[] u = GameObject.Find("Equipments").GetComponentsInChildren<Upgrade>();
		foreach(Upgrade t in u){
			if(t.id == Investimentos.Tipo.Camera || t.id == Investimentos.Tipo.Microfone || t.id == Investimentos.Tipo.SoftwareDeGravacao ){
				equipment.Add(t);				
			}
		}
	}

	void Comentar(){
		int i = getEquipmentToComment();
		string s = comentario[i][ UnityEngine.Random.Range(0,comentario[i].Length)  ];
		// printar s como comentario
	}

	int getEquipmentToComment(){
		equipment.Sort(delegate(Upgrade u1, Upgrade u2){
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
