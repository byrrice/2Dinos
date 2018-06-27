using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneDialogue : MonoBehaviour {

	[SerializeField] Canvas messageCanvas;
	public float messageTime = 0f;
	public float delay = 0f;

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
			StartCoroutine(SendMessage());
		}
	}
	public IEnumerator SendMessage() {
		yield return new WaitForSeconds(delay);
		messageCanvas.enabled = true;
		yield return new WaitForSeconds(messageTime); // waits for message time
		messageCanvas.enabled = false;
 	}
}
