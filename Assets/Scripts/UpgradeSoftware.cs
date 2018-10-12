using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSoftware : Investimentos {

	// Use this for initialization
	protected override void Start () {
		base.Start();
		id = Tipo.SoftwareDeGravacao;
		isEquipment = true;
		custo = new int[] {50,90,700};
		tempo = new int[] {3,5,5};
	}
	
	public override void Efeito(){
		
	}

	// Update is called once per frame
	void Update () {
		
	}
}
