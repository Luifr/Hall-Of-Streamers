using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour {

	public Animator ship;
	public Animator[] explosions;


	public void Refresh(){
		ship.SetInteger("pos",Random.Range(0,2));
		explosions[Random.Range(0,explosions.Length - 1)].SetTrigger("explode");
	}
}
