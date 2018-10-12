using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoControl : MonoBehaviour {

	public Investimentos[] equips;
	public int[] tests;

	[Space(10)]
	public Gameplay[] screens;
	int currScreen;

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


	float cTime, sTime;
	// Use this for initialization
	void Start () {
		sTime = Time.time;
		currScreen = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		cTime = Time.time;

		if (cTime - sTime >= pAnimTime){
			pAnim = Random.Range(0,3);
			playerAnim.SetInteger("anim",pAnim);
			sTime = Time.time;
			screens[currScreen].Refresh();
		}

		if (equips.Length > 0){
			scenario.sprite = cams[equips[0].currentTier];
			microphone.sprite = mics[equips[1].currentTier];
			if (currScreen != equips[0].currentTier){
				screens[currScreen].gameObject.SetActive(false);
				currScreen = equips[0].currentTier;
				screens[currScreen].gameObject.SetActive(true);
			}
		}else{
			scenario.sprite = cams[tests[0]];
			microphone.sprite = mics[tests[1]];
			if (currScreen != tests[0]){
				screens[currScreen].gameObject.SetActive(false);
				currScreen = tests[0];
				screens[currScreen].gameObject.SetActive(true);
			}
		}
	}
}
