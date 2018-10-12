using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Relogio : MonoBehaviour {

	private float timer;
	public static int ticks;
	private float secPerTick = 2;
	private int ticksPerDay = 61;
	public static DateTime data;
	public Text dataText;

	// Use this for initialization
	void Start () {
		dataText = GameObject.Find ("DataAtual").GetComponent<Text> ();
		data = DateTime.Now;
		data = data.Date + new TimeSpan(12,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Atributos.fastForward) {
			secPerTick = 0.5f;
		} else {
			secPerTick = 2;
		}
		timer += Time.deltaTime;
		if (timer >= secPerTick) {
			timer = 0;
			ticks++;
			data = data.AddDays (1 / (float)(ticksPerDay));
			//data.AddDays(1/ticksPerDay);
		}
		DisplayData ();
	}

	public void DisplayData () {
		dataText.text = data.ToString("dd/MM/yy  HH:mm");
	}
}
