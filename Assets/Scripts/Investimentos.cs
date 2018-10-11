using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Investimentos : MonoBehaviour {

	private int[] custo;
	private float[] tempo;
	private int currentTier;
	private int maxTier;
	private int id;
	private enum Tipo { Microfone, Camera , SoftwareDeGravacao , Carisma , Montagem }

	// Use this for initialization
	void Start () {
		currentTier = 0;
	}

	void Investir(){
		
	}

	public abstract void Efeito();
	
	// Update is called once per frame
	void Update () {
		
	}
}
