using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMontagem : Investimentos {

	// Use this for initialization
	protected override void Start () {
		base.Start();
		id = Tipo.Montagem;
		isEquipment = false;
	}
	
	public override void Efeito(){
		
	}

	// Update is called once per frame
	void Update () {
		
	}
}
