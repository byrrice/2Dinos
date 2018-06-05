using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour {

	public GameObject childObj;

	// Use this for initialization
	void Start () {
		childObj.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void onTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Player"){
			childObj.SetActive(true);
		}
	}

	void onTriggerExit2D(Collider2D collider){
		if (collider.tag == "Player"){
			childObj.SetActive(false);
		}
	}
}
