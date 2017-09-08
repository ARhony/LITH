using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class sRegionInput : MonoBehaviour {
	//Float
	private int iNbZones = 7;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)){
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 5.0f) && checkHitZoneTag(hit.collider.tag)){
				GameObject goHit = hit.collider.gameObject;
				sRegionManager sRegMan = goHit.GetComponentInParent<sRegionManager>();
				//sZoneManager sZonMan = goHit.transform.parent.GetComponent<sZoneManager>();
				Debug.Log(hit.collider.tag);
				//sZonMan.ControlZoneHit(System.Convert.ToInt32(hit.collider.tag));
			}
		}
	}

	private bool checkHitZoneTag(string tag){
		for(int i = 0; i < iNbZones; i++){
			if (string.Compare(tag, i.ToString()) == 0){
				return (true);
			}
		}
		return (false);
	}
}
