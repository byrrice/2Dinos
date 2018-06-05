using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {
	
	public string level;

	void Start(){

	}
	void Update(){

	}

	void OnTriggerEnter2D(Collider2D trigger){
		if (trigger.tag == "Player"){
			SceneManager.LoadScene(level);
		}
	}
}
