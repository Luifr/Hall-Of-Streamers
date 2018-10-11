using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Relogio : MonoBehaviour {

	private float timer;
	public static int ticks;
	private float secPerTick = 3;
	private int ticksPerDay = 61;
	public static DateTime data;

	// Use this for initialization
	void Start () {
		data = DateTime.Now;
		data = data.Date + new TimeSpan(12,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		data = data.AddDays(1/(float)(ticksPerDay*secPerTick));
		if(timer >= secPerTick){
			timer-=secPerTick;
			ticks++;
			//data.AddDays(1/ticksPerDay);
		}
	}
}
