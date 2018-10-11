using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Investimentos : MonoBehaviour {

	private int[] custo;
	private float[] tempo;
	public DateTime ultimoUpgrade;
	public int currentTier;
	private int maxTier;
	public enum Tipo { Microfone, Camera , SoftwareDeGravacao , Carisma , Montagem }
	public Tipo id;

	// Use this for initialization
	protected virtual void Start () {
		currentTier = 0;
	}

	void Investir(){
		currentTier = Mathf.Max(currentTier+1,maxTier);
		ultimoUpgrade = DateTime.Now;
	}

	public abstract void Efeito();
	
	// Update is called once per frame
	void Update () {
		
	}
}
