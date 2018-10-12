using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoControl : MonoBehaviour {

	public Investimentos[] equips;
	public int[] tests;
	
	[Space(10)]
	public Image scenario;
	public Sprite[] cams;

	[Space(10)]
	public Image microphone;
	public Sprite[] mics;

	[Space(10)]
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
		}

		if (equips.Length > 0){
			scenario.sprite = cams[equips[0].currentTier];
			microphone.sprite = mics[equips[1].currentTier];
		}else{
			scenario.sprite = cams[tests[0]];
			microphone.sprite = mics[tests[1]];
		}
	}
}
