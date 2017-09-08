using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sZoneManagerTop : MonoBehaviour {

	//Materials
	public Material mZoneOwned;
	//Gameobjects
	private GameObject[] goZones;
	public bool bTop = true;

	public sZoneManagerMid sMid;
	private bool bMid = false;
	
	//Floats
	private int iNbZones = 7;

	// Use this for initialization
	void Start () {
		sMid = this.transform.parent.GetChild(1).gameObject.GetComponent<sZoneManagerMid>();
		goZones = new GameObject[iNbZones];
		for(int i = 0; i < iNbZones; i++){
			goZones[i] = this.gameObject.transform.GetChild(i).gameObject;
			goZones[i].SetActive(false);
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

	public void SetupTopMap(int[] midMap){
		for(int i = 0; i < iNbZones; i++){
			if (midMap[i] == 0){ i++; }
			else if (Random.value > 0.66f && midMap[i] == 1){
				goZones[i].SetActive(true);
			}
		}
		bTop = false;
	}
}
