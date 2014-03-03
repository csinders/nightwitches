using UnityEngine;
using System.Collections;

public class AirplaneController : MonoBehaviour {
	
	public float accelerationRate; //push up on keyboard buttons, how fast plane increase or decrease speed
  public GameObject bombPrefab;
  public Camera mainCamera;
  public float yawRate;

	private float speed; //not for the editor to have access to, calculated at start of game
  private bool previous_moving;

	// Use this for initialization
	void Start() {
		speed = 0.0f;
    previous_moving = false;
	}

  void OnTriggerEnter2D(){
    GameObject.Destroy(gameObject);

  }
	
	// Update is called once per frame
	void FixedUpdate() {
		//get input from player into two variables 
		var yaw = yawRate * Input.GetAxis("Horizontal"); //gives input for LR arrows 
		var acceleration = accelerationRate * Input.GetAxis("Vertical"); //gives input for Up Down arrows
    acceleration = Mathf.Clamp(acceleration, 0.0f, accelerationRate);
    bool moving = false;
    if (acceleration > 0.0) {
      gameObject.rigidbody2D.gravityScale = 0.0f;
      moving = true;
    } else {
      gameObject.rigidbody2D.gravityScale = 1.0f;
    }

		//update airplanes position and rotation
    if (moving && !previous_moving) {
      gameObject.rigidbody2D.velocity = 5.0f * gameObject.transform.up;
    }
    gameObject.rigidbody2D.AddForce(acceleration * gameObject.transform.up);
    gameObject.rigidbody2D.AddTorque(-yaw * (moving ? 1.0f : 2.0f));
    gameObject.rigidbody2D.AddTorque(-0.01f * gameObject.rigidbody2D.angularVelocity);
    gameObject.rigidbody2D.velocity = Vector2.ClampMagnitude(gameObject.rigidbody2D.velocity, 5.0f);

    // Create a bomb
    if (Input.GetKeyDown("space")) {
      var bomb = Object.Instantiate(bombPrefab) as GameObject;
      bomb.transform.position = transform.position - Vector3.up;
      bomb.rigidbody.velocity = speed * gameObject.transform.up;
      bomb.rigidbody.rotation = gameObject.transform.rotation;
      Debug.Log("Clip length: " + bomb.GetComponent<AudioSource>().clip.length);
      Debug.Log("Fall time: " + Mathf.Sqrt(2.0f * bomb.transform.position.y / -Physics.gravity.y));
      bomb.GetComponent<AudioSource>().pitch = bomb.GetComponent<AudioSource>().clip.length / Mathf.Sqrt(2.0f * bomb.transform.position.y / -Physics.gravity.y);
    }

    var cameraPosition = Vector2.Lerp(mainCamera.transform.position, gameObject.transform.position, 0.2f);
    mainCamera.transform.position = new Vector3(cameraPosition.x, cameraPosition.y, mainCamera.transform.position.z);
    previous_moving = moving;
	}
}
