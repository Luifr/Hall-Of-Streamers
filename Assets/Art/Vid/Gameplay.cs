using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour {

	public Image bg;
    public Sprite newBg;
    public Animator ship1, ship2;
	public Animator[] explosions1, explosions2;

    int lvl;

	public void Upgrade(int newLvl){
		if (newLvl == 2){
			if (lvl != newLvl){
                ship1.gameObject.SetActive(false);
                ship2.gameObject.SetActive(true);
            }
			
		}else if (newLvl == 3) bg.sprite = newBg;
        lvl = newLvl;
	}

    public void Refresh(){
		if (lvl >= 2){
			ship2.SetInteger("pos",Random.Range(0,2));
			explosions2[Random.Range(0,explosions1.Length - 1)].SetTrigger("explode");
		}else if (lvl == 1){
			ship1.SetInteger("pos",Random.Range(0,2));
			explosions2[Random.Range(0,explosions1.Length - 1)].SetTrigger("explode");
		}else{
			ship1.SetInteger("pos",Random.Range(0,2));
			explosions1[Random.Range(0,explosions1.Length - 1)].SetTrigger("explode");
        }
    }
}
