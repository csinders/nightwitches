using UnityEngine;
using System.Collections;

public class AirplaneController : MonoBehaviour {

	public float accelerationRate;
	public float glideRate;	
	public float heightFromSpeed;
	public Camera mainCamera;
  public GameObject bombPrefab;

	private float speed;
	private float targetCameraAltitude;

	// Use this for initialization
	void Start() {
		speed = 0.0f;
		targetCameraAltitude = mainCamera.transform.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		// Get input from player
		var yaw = 2.0f * Input.GetAxis("Horizontal");
		var acceleration = accelerationRate * Input.GetAxis("Vertical");

		// Update the airplane's position and rotation
		gameObject.transform.rotation = CalculateNewRotation(gameObject.transform.rotation, yaw);
		gameObject.transform.position = CalculateNewPosition(gameObject.transform.position);

		// Update the camera's position
		mainCamera.transform.position = CalculateNewCameraPosition(gameObject.transform.position);

		// Update the airplane's speed
		speed = CalculateNewSpeed(acceleration);

    // Create a bomb
    if (Input.GetKeyDown("space")) {
      var bomb = Object.Instantiate(bombPrefab) as GameObject;
      bomb.transform.position = transform.position - Vector3.up;
      bomb.rigidbody.velocity = speed * gameObject.transform.up;
      Debug.Log(bomb.rigidbody.velocity);
    }
	}

	Vector3 CalculateNewCameraPosition(Vector3 airplane) {
		return new Vector3(airplane.x, targetCameraAltitude, airplane.z);
	}

	Vector3 CalculateNewPosition(Vector3 position) {
		position += speed * gameObject.transform.up * Time.deltaTime;
		position.y = heightFromSpeed * speed;
		return position;
	}

	Quaternion CalculateNewRotation(Quaternion rotation, float yaw) {
		var yawRotation = Quaternion.AngleAxis(yaw, Vector3.up);
		return yawRotation * rotation;
	}

	float CalculateNewSpeed(float acceleration) {
		var newSpeed = speed + (acceleration - glideRate) * Time.deltaTime;
		return Mathf.Clamp(newSpeed, 0.0f, targetCameraAltitude);
	}
}
