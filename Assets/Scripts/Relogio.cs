using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Relogio : MonoBehaviour {

	private float timer;
	public static int ticks;
	private float secPerTick = 4;
	private int ticksPerDay = 60;
	public static DateTime dia;

	// Use this for initialization
	void Start () {
		dia = DateTime.Now;
		dia = dia.Date + new TimeSpan(12,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer >= secPerTick){
			timer-=secPerTick;
			ticks++;
			dia.AddDays(1/ticksPerDay);
		}
	}
}
