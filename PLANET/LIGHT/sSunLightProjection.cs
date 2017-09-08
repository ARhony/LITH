using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sSunLightProjection : MonoBehaviour {

	//Float
	private float fSpeed;

	//GameObject
	private GameObject goPlanet;
	// Use this for initialization
	void Start () {
		fSpeed = 5.0f;
		goPlanet = GameObject.FindGameObjectWithTag("planet");
	}
	
	// Update is called once per frame
	void Update () {
		//this.transform.Rotate(Vector3.up * Time.deltaTime * fSpeed);
		this.transform.LookAt(goPlanet.transform);
	}
}
