//  LITH
//  PLANET/sRegionManager.cs
//  Initialize each region
//  Anthony Ramon
//  08/21/17

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sLayerManager : MonoBehaviour {

	//GameObject
	private GameObject[] goLayers;

	//Float
	private int iNbLayer = 3;

	// Use this for initialization
	void Start () {
		goLayers = new GameObject[iNbLayer];
		for(int i = 0; i < iNbLayer; i++){
			goLayers[i] = this.gameObject.transform.GetChild(i).gameObject;
			goLayers[i].tag = i.ToString();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
