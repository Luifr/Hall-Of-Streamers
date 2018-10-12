using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public abstract class Investimentos : MonoBehaviour {

	[SerializeField]
	private Sprite[] sprites;
	protected int[] custo;
	protected int[] tempo;
	public DateTime ultimoUpgrade;
	[NonSerialized]
	public int currentTier;
	protected bool isEquipment;

	public enum Tipo { Microfone, Camera , SoftwareDeGravacao , Carisma , Montagem , Size}
	
	[NonSerialized]
	public Tipo id;
	private Atributos attr;
	public static int finished;

	// Use this for initialization
	protected virtual void Start () {
		var a = GameObject.Find("Atributos");
		attr = a.GetComponent<Atributos>();
	}

	public void Investir(Button button){
		if(currentTier < custo.Length && Atributos.dinheiro >= custo[currentTier] ){
			Atributos.delayFinish = Relogio.data.AddHours(tempo[currentTier]);
			if(isEquipment){
			/*	Atributos.delay -= currentTier; // ATUALIZAR ISSO QUANDO COMPRAR O INFORMATICA
				Atributos.delay = Mathf.Max(0,Atributos.delay);
			*/	EquipButton(button);
			}
			else{
				CourseButton(button);
			}
			Atributos.dinheiro -= custo[currentTier];
			currentTier = currentTier+1;
			if(currentTier == custo.Length){
				finished++;
			}
			ultimoUpgrade = DateTime.Now;
			Atributos.rating+=40;
			attr.viewers = 0;
			attr.AtualizaAtributos();
		}
	}

	void EquipButton(Button button){
		if(currentTier+1 < custo.Length){
			button.transform.Find("Photo").GetComponentInChildren<Image>().sprite = sprites[currentTier+1];
			button.transform.Find("Text").GetComponentInChildren<Text>().text = "R$ " + custo[currentTier+1];
			button.transform.Find("Text (1)").GetComponentInChildren<Text>().text = "Instalação: " + tempo[currentTier+1] + "h";
		}
		else{
			button.transform.Find("Text").GetComponentInChildren<Text>().text = "Voce possui o melhor deste item do mercado";
			button.transform.Find("Text (1)").GetComponentInChildren<Text>().text = "";
		}
	}

	void CourseButton(Button button){
		if(currentTier+1 < custo.Length){
			button.transform.Find("Text").GetComponentInChildren<Text>().text = "R$ " + custo[currentTier+1];
			button.transform.Find("Text (1)").GetComponentInChildren<Text>().text = "Duração do curso: " + tempo[currentTier+1] + "h";
		}
		else{
			button.transform.Find("Text").GetComponentInChildren<Text>().text = "";
			button.transform.Find("Text (1)").GetComponentInChildren<Text>().text = "Voce ja é doutor no assunto";
			button.transform.Find("Text (2)").GetComponentInChildren<Text>().text = "";
		}
	}

	public abstract void Efeito();
	
	// Update is called once per frame
	void Update () {
		
	}
}
