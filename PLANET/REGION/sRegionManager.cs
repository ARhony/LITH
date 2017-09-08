//  LITH
//  PLANET/sRegionManager.cs
//  Initialize each region
//  Anthony Ramon
//  08/21/17

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Note: Each region is between 2 stonewell. Only one region per hemispher is etween the same stone well duo.
//		So let's cut the planet half (North/South)
public class sRegionManager : MonoBehaviour {

	//GameOjects
	private GameObject[] goRegions;
	
	//Floats
	public int iNbRegion = 30;
	// Use this for initialization
	void Start () {
		goRegions = new GameObject[iNbRegion];
		goRegions = GameObject.FindGameObjectsWithTag("region");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
