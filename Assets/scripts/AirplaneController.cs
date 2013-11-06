using UnityEngine;
using System.Collections;

public class AirplaneController : MonoBehaviour {
	
	public Camera mainCamera;

	private Vector3 cameraOffset;
	private float velocity;

	// Use this for initialization
	void Start() {
		cameraOffset = mainCamera.transform.position - gameObject.transform.position;
		velocity = 100.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		var yaw = 2.0f * Input.GetAxis("Horizontal");
		var yawRotation = Quaternion.AngleAxis(yaw, Vector3.up);
		gameObject.transform.rotation = yawRotation * gameObject.transform.rotation;
		gameObject.transform.position += velocity * gameObject.transform.up * Time.deltaTime;
	}
	
	void Update() {
		var position = mainCamera.transform.position;
		position.x = gameObject.transform.position.x + cameraOffset.x;
		position.z = gameObject.transform.position.z + cameraOffset.z;
		mainCamera.transform.position = position;
	}
}
