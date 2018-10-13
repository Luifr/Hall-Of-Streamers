using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Relogio : MonoBehaviour {

	[SerializeField]
	private GameObject win;
	[SerializeField]
	private GameObject setaC;
	[SerializeField]
	private GameObject setaM;
	[SerializeField]
	private GameObject tutorial;
	private Text tutorialText;
	private float timer=0;
	public static float timer2;
	public static int ticks;
	private float secPerTick = 2;
	private int ticksPerDay = 61;
	public static DateTime data;
	public static DateTime start;
	public Text dataText;

	private string[] messages = new string[] {
		"Eae jovem streamer, eu sou o xtreamer, mas voce ja deve me conhecer não é?\n-------------------------------------\nClique nesta caixa para fechar-la",
		"Fiquei sabendo que voce quer ser um streamer tambem\nFique ligado nos comentarios, e sempre melhore seu equipamento!",
		"O botão de compartilhar pode ser muito util, ele atrai mais usuarios para sua stream, mas não abuse, eles ficam bravos",
		"Isso aqui e a loja, la voce pode comprar os equipamentos que eu mencionei, eles atrairam o pessoal!",
	};

	public static int count;
	private float[] times = new float[] {0,0,0,0};

	// Use this for initialization
	void Start () {
		tutorialText = tutorial.transform.Find("Text").GetComponent<Text>();
		dataText = GameObject.Find ("DataAtual").GetComponent<Text> ();
		data = DateTime.Now;
		start = DateTime.Now;
		data = data.Date + new TimeSpan(12,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		// Checa fim de jogo
		if(Investimentos.finished == (int)Investimentos.Tipo.Size && BancoDoBrasil.dinheiroEmprestado == 0){
			win.SetActive(true);	
			win.GetComponentInChildren<Text>().text = "Parabéns voce conseguiu o melhor setup streamer disponivel no mercado em " + (data-start).Days + " dias!\nSera que consegue fazer mais rapido?";		
		}


		if (Atributos.fastForward) {
			secPerTick = 0.5f;
		} else {
			secPerTick = 2;
		}
		timer += Time.deltaTime;
		timer2 += Time.deltaTime;
		//Debug.Log(count + " " + times.Length + " " + tutorial.activeInHierarchy + " " + times[count] + " " + timer);
		if(count < times.Length && timer2 >= times[count] && !tutorial.activeInHierarchy ){
			tutorial.SetActive(true);
			tutorialText.text = messages[count++];
			Time.timeScale = 0;
			if(count==3){
				setaC.SetActive(true);
			}
			else if(count==4){
				setaM.SetActive(true);
			}
		}
		if(timer >= secPerTick){
			timer-=secPerTick;
			ticks++;
			data = data.AddDays (1 / (float)(ticksPerDay));
			//data.AddDays(1/ticksPerDay);
		}
		DisplayData ();
	}

	public void DisplayData () {
		dataText.text = data.ToString("dd/MM/yy  HH:mm");
	}

	public void TimeBack(){
		Time.timeScale = 1;
		setaC.SetActive(false);
		setaM.SetActive(false);
	}
}
