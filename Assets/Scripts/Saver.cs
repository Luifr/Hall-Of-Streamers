using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Saver : MonoBehaviour {

	public static bool load = true;
	private Investimentos[] equips;

	private string filename = "playerdata.dat";

	// Use this for initialization
	void Start () {
		equips = GameObject.Find("Equipments").GetComponentsInChildren<Investimentos>();
		if(load)
			Load();
	}
	
	public void Save(){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Open(Application.persistentDataPath + "/" + filename, FileMode.OpenOrCreate);

		PlayerData data = new PlayerData();
		data.rep = Atributos.rep;
		data.dinheiro = Atributos.dinheiro;
		data.date = Relogio.data.ToString();
		foreach(Investimentos i in equips){
			if(i is UpgradeCamera){
				data.camLV = i.currentTier;
			}
			else if(i is UpgradeMicrofone){
				data.micLV = i.currentTier;
			}
			else if(i is UpgradeSoftware){
				data.softLV = i.currentTier;
			}
			else if(i is UpgradeCarisma){
				data.carismaLV = i.currentTier;
			}
			else if(i is UpgradeInformatica){
				data.infoLV = i.currentTier;
			}
		}

		bf.Serialize(file,data);
		file.Close();
	}

	void Load(){
		if(!File.Exists(Application.persistentDataPath + "/" + filename)){
			foreach(Investimentos i in equips){
				i.currentTier = 0;
			}	
			Atributos.rep = 0;
			Atributos.dinheiro = 0;
			return;
		}
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Open(Application.persistentDataPath + "/" + filename, FileMode.Open);
		PlayerData data = (PlayerData)bf.Deserialize(file);
		Debug.Log("load money " + data.dinheiro);
		Atributos.rep = data.rep;
		Atributos.dinheiro = data.dinheiro;
		Relogio.data = DateTime.Parse(data.date);
		foreach(Investimentos i in equips){
			if(i is UpgradeCamera){
				i.currentTier = data.camLV;
			}
			else if(i is UpgradeMicrofone){
				i.currentTier = data.micLV;
			}
			else if(i is UpgradeSoftware){
				i.currentTier = data.softLV;
			}
			else if(i is UpgradeCarisma){
				i.currentTier = data.carismaLV;
			}
			else if(i is UpgradeInformatica){
				i.currentTier = data.infoLV;
			}
		}

		file.Close();
	}

	[Serializable]
	class PlayerData{
		public int camLV,micLV,softLV,carismaLV,infoLV;
		public int rep;
		public float dinheiro;
		public string date;
	}

}

