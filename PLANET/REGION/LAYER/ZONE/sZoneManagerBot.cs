//  LITH
//  sZoneManager
//  Initialize each zone of the region
//  Anthony Ramon
//  08/21/17

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sZoneManagerBot : MonoBehaviour {

	//Materials
	public Material mZoneOwned;
	//Gameobjects
	private GameObject[] goZones;

	//Floats
	private int iNbZones = 7;

	// Use this for initialization
	void Start () {
		goZones = new GameObject[iNbZones];
		for(int i = 0; i < iNbZones; i++){
			goZones[i] = this.gameObject.transform.GetChild(i).gameObject;
			goZones[i].SetActive(true);
			goZones[i].tag = i.ToString();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ControlZoneHit(int num){
		for(int i = 0; i < iNbZones; i++){
			if (i == num){
				Renderer tmpRend = goZones[i].GetComponent<Renderer>();
				tmpRend.material = mZoneOwned;
			}
		}
	}
}
