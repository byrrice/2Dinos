using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour {

	[SerializeField] Canvas messageCanvas;

	// Use this for initialization
	void Start () {
		messageCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//GOT CUTSCENES WORKING THANK GOD HOLY CAPTIALIZE AN O
	//Need to set up a sprite to tell us that it is a hint/dialogue system
	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Player"){
			messageCanvas.enabled = true;
		}
	}

	void OnTriggerExit2D(Collider2D collider){
		if (collider.tag == "Player"){
			messageCanvas.enabled = false;
		}
	}
}
