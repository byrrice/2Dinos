using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// set active true and false, spawn in same position and swoitj camera
public class SwitchCharacterScript : MonoBehaviour {

	// references to the players
	public GameObject player1, player2;
	Vector3 storedposition;
	

	// which avatar is on right now
	int whichAvatarIsOn = 1;

	// Use this for initialization
	void Start () {

		// enable first avatar and disable another one
		player1.gameObject.SetActive (true);
		player2.gameObject.SetActive (false);
		// player1.gameObject.GetComponent<SpriteRenderer>().enabled = true;
		// player2.gameObject.GetComponent<SpriteRenderer>().enabled = false;
	}

	void FixedUpdate(){
		SwitchAvatar();
	}

	// public method to switch avatars by pressing UI button
	public void SwitchAvatar()
	{

		// processing whichAvatarIsOn variable
		if (Input.GetKeyDown(KeyCode.K)) {

			// if the first avatar is on
			if (whichAvatarIsOn == 1){

				// then the second avatar is on now
				whichAvatarIsOn = 2;

				// disable the first one and enable the second one
				storedposition = player1.gameObject.transform.position;
				player1.gameObject.SetActive (false);
				player2.gameObject.transform.position = storedposition;
				player2.gameObject.SetActive (true);
				//NEED TO DISABLE COLLIDERS
				// player1.gameObject.GetComponent<SpriteRenderer>().enabled = false;
				// player2.gameObject.GetComponent<SpriteRenderer>().enabled = true;
				
			}

			// if the second avatar is on
			else {

				// then the first avatar is on now
				whichAvatarIsOn = 1;

				// disable the second one and enable the first one
				storedposition = player2.gameObject.transform.position;
				player2.gameObject.SetActive (false);
				player1.gameObject.transform.position = storedposition;
				player1.gameObject.SetActive (true);
				
				
				// player2.gameObject.GetComponent<SpriteRenderer>().enabled = false;
				// player1.gameObject.GetComponent<SpriteRenderer>().enabled = true;
				
			}
		}
			
	}
}
