using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoControl : MonoBehaviour {

	
	public Animator playerAnim;
	public float pAnimTime, pRandom;
	int pAnim = 0;

	float cTime, sTime, rTime;
	// Use this for initialization
	void Start () {
		sTime = Time.time;
		rTime = Random.Range(0.0f, pRandom);
	}
	
	// Update is called once per frame
	void Update () {
		cTime = Time.time;
		if (cTime - sTime >= pAnimTime + rTime){
			pAnim = Random.Range(0,3);
			playerAnim.SetInteger("anim",pAnim);
			Debug.Log("foi");
		}
	}
}
