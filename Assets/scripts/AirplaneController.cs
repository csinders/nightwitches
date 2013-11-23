using UnityEngine;
using System.Collections;

public class AirplaneController : MonoBehaviour {
	
	public float accelerationRate; //push up on keyboard buttons, how fast plane increase or decrease speed
	public float glideRate;  //natural decrease that is constantly slowing down 
	public float heightFromSpeed;  //ratio between speed and height, speed controls airplane 
	public Camera mainCamera;
  public GameObject bombPrefab;

	private float speed; //not for the editor to have access to, calculated at start of game 
	private float targetCameraAltitude;

	// Use this for initialization
	void Start() {
		speed = 0.0f;
		targetCameraAltitude = mainCamera.transform.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		//get input from player into two variables 
		var yaw = 2.0f * Input.GetAxis("Horizontal"); //gives input for LR arrows 
		var acceleration = accelerationRate * Input.GetAxis("Vertical"); //gives input for Up Down arrows 


		//update airplanes position and rotatoin 
		gameObject.transform.rotation = CalculateNewRotation(gameObject.transform.rotation,yaw); //comma instead of dot b/c im passing two arguments 
		gameObject.transform.position = CalculateNewPosition(gameObject.transform.position);

		//update camera position
		mainCamera.transform.position = CalculateNewCameraPosition(gameObject.transform.position);

		//update the airplane's speed
		speed = CalculateNewSpeed(acceleration);

    // Create a bomb
    if (Input.GetKeyDown("space")) {
      var bomb = Object.Instantiate(bombPrefab) as GameObject;
      bomb.transform.position = transform.position - Vector3.up;
      bomb.rigidbody.velocity = speed * gameObject.transform.up;
      Debug.Log(bomb.rigidbody.velocity);
    }
	}
	
	Vector3 CalculateNewCameraPosition(Vector3 airplane){
		return new Vector3(airplane.x, targetCameraAltitude, airplane.z);
	}

	Vector3 CalculateNewPosition(Vector3 position){
		position += speed * gameObject.transform.up * Time.deltaTime;
		position.y = heightFromSpeed + speed;
		return position;
	}

	Quaternion CalculateNewRotation(Quaternion rotation, float yaw){
		var yawRotation = Quaternion.AngleAxis(yaw, Vector3.up);
		return yawRotation * rotation; 
	}

	float CalculateNewSpeed(float acceleration){
		var newSpeed = speed + (acceleration - glideRate) * Time.deltaTime;
		return Mathf.Clamp(newSpeed, 0.0f, targetCameraAltitude);
	}
}
