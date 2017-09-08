using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sGameManager : MonoBehaviour {

	//float
	public int iNbTurn = 20;
	public float fTimePerTurn = 5.0f;
	public float fTimerTurn = 5.0f;

	//int
	public int iCurrentPlayer = 1;

	//Text
	public Text tTurnTimer;
	public bool bEndTurn = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (!bEndTurn){
			fTimerTurn -= Time.deltaTime;
			tTurnTimer.text = Mathf.Floor(fTimerTurn).ToString();
			if (fTimerTurn < 0.0f){
				bEndTurn = true;
				fTimerTurn = 5.0f;
			}
		} else {
			fTimerTurn = fTimePerTurn;
		}
	}

	public void endTurn(){ bEndTurn = true; }

}
