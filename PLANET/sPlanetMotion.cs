using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sPlanetMotion : MonoBehaviour {

	//Extern Scripts
	private sGameManager sGame;

	//Float
	private float fDist;
	private float fAngle;

	// Use this for initialization
	void Start () {
		sGame = GameObject.FindGameObjectWithTag("system").GetComponent<sGameManager>();
		fDist = this.transform.position.x;
		fAngle = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (sGame.bEndTurn){
			Vector3 v3Origin = Vector3.zero;
			float y = this.transform.position.y;
			Vector3 tCurPos = new Vector3(v3Origin.x + (fDist * Mathf.Cos(Mathf.Deg2Rad * fAngle)), y,v3Origin.z - (fDist * Mathf.Sin(Mathf.Deg2Rad * fAngle)));
			this.transform.position = tCurPos;
			fAngle += (360 / 20);
			sGame.bEndTurn = false;
		}
	}
}
