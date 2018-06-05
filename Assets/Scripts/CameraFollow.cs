using UnityEngine;

public class CameraFollow : MonoBehaviour {

	//Pause Menu Interaction???

	// two character players to follow
	public Transform target1;
	public Transform target2;

	// which avatar it is currently on
	int whichAvatarIsOn = 1;		
	public float smoothSpeed = .125f;
	public Vector3 offset;
	Vector3 velocity = Vector3.zero;

	void FixedUpdate(){
		//checks to update camera, might not need check for whichAvatarisOn
		if (whichAvatarIsOn == 1){
			Vector3 desiredPosition = target1.position + offset;
			Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
			transform.position = smoothedPosition;
		}
		if (whichAvatarIsOn == 2){
			Vector3 desiredPosition = target2.position + offset;
			Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
			transform.position = smoothedPosition;
		}
		if (Input.GetKeyDown(KeyCode.K) && whichAvatarIsOn == 1){
			whichAvatarIsOn = 2;
		}
		else if (Input.GetKeyDown(KeyCode.K) && whichAvatarIsOn == 2){
			whichAvatarIsOn = 1;
		}
	}
}
