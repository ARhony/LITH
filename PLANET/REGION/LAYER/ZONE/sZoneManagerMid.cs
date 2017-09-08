using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sZoneManagerMid : MonoBehaviour {

	//Materials
	public Material mZoneOwned;
	public sZoneManagerTop sTop;
	//Gameobjects
	private GameObject[] goZones;

	//Floats
	private int iNbZones = 7;
	public int[] iMid = new int[7];

	// Use this for initialization
	void Start () {
		sTop = this.transform.parent.GetChild(2).gameObject.GetComponent<sZoneManagerTop>();
		goZones = new GameObject[iNbZones];
		for(int i = 0; i < iNbZones; i++){
			goZones[i] = this.gameObject.transform.GetChild(i).gameObject;
			goZones[i].SetActive(false);
			goZones[i].tag = i.ToString();
		}
		iMid = SetupMidMap();
		//sTop.SetupTopMap(tmp);
	}
	
	// Update is called once per frame
	void Update () {
		if (sTop.bTop){ sTop.SetupTopMap(iMid); }
	}

	public void ControlZoneHit(int num){
		for(int i = 0; i < iNbZones; i++){
			if (i == num){
				Renderer tmpRend = goZones[i].GetComponent<Renderer>();
				tmpRend.material = mZoneOwned;
			}
		}
	}

	int[] SetupMidMap(){
		int[] tmp = {0, 0, 0, 0, 0, 0, 0};
		for(int i = 0; i < iNbZones; i++){
			if (Random.value > 0.33f){
				tmp[i] = 1;
				goZones[i].SetActive(true);
			}
		}
		return (tmp);
	}
}
