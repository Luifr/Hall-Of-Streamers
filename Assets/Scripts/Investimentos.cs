using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Investimentos : MonoBehaviour {

	private Atributos attr;
	private int[] custo;
	private int[] tempo;
	public DateTime ultimoUpgrade;
	[NonSerialized]
	public int currentTier;
	private int maxTier;

	public enum Tipo { Microfone, Camera , SoftwareDeGravacao , Carisma , Montagem }
	
	[NonSerialized]
	public Tipo id;

	// Use this for initialization
	protected virtual void Start () {
		currentTier = 0;
		maxTier=1;
		attr = GameObject.Find("Atributos").GetComponent<Atributos>();
	}

	void Investir(){
		if(attr.dinheiro >= custo[currentTier] && currentTier < maxTier){
			attr.dinheiro -= custo[currentTier];

			currentTier = currentTier+1;
			ultimoUpgrade = DateTime.Now;
			Atributos.rating+=40;
		}
	}

	public abstract void Efeito();
	
	// Update is called once per frame
	void Update () {
		
	}
}
