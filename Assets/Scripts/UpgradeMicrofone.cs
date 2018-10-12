using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMicrofone : Investimentos {

	// Use this for initialization
	protected override void Start () {
		base.Start();
		id = Tipo.Microfone;
		isEquipment = true;
		custo = new int[] {10,80,300};
		tempo = new int[] {3,5,5};
	}
	
	public override void Efeito(){
		
	}

	// Update is called once per frame
	void Update () {
		
	}
}
