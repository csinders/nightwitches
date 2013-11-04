using UnityEngine;
using System.Collections;

public class AirplaneController : MonoBehaviour {

  private const float INITIAL_SPEED = 100.0f;
  private const string LEFT_HORIZONTAL = "Horizontal";
  private const string LEFT_VERTICAL = "Vertical";
  private const string RIGHT_HORIZONTAL = "RightHorizontal";
  private const string RIGHT_VERTICAL = "RightVertical";
  private const string THROTTLE = "Throttle";
	
	public Camera mainCamera;
	public float minimumCameraDistance;
	public float cameraMixRate;
	public float throttle;
	public float jerk;
	public float dragAmount;
	public float dragParameter;
	public float liftAmount;
	public float liftParameter;
	public float torque;
	
	private Vector3 acceleration;

	// Use this for initialization
	void Start() {
		rigidbody.velocity = INITIAL_SPEED * rigidbody.transform.forward;
		acceleration = Vector3.zero;
	}
	
	// Update is called once per frame
	void FixedUpdate() {

    for (int i = 0; i < 19; ++i) {
      if (Input.GetKey("joystick button " + i)) {
        Debug.Log("joystick button " + i);
      }
    }
		
		acceleration = Input.GetAxis(RIGHT_VERTICAL) * throttle * rigidbody.mass * gameObject.transform.forward;
		if (Input.GetKey(KeyCode.Alpha1)) {
			acceleration = throttle * rigidbody.mass * gameObject.transform.forward;
		}
		if (Input.GetKey(KeyCode.Alpha2)) {
			acceleration = -throttle * rigidbody.mass * gameObject.transform.forward;
		}
		
		float pitch = 5.0f * torque * Input.GetAxis(LEFT_VERTICAL);
		float roll = -torque * Input.GetAxis(LEFT_HORIZONTAL);
		float yaw = 5.0f * torque * Input.GetAxis(RIGHT_HORIZONTAL);
		if (Input.GetKey(KeyCode.Comma)) {
			yaw = -5.0f * torque;
		}
		if (Input.GetKey (KeyCode.Period)) {
			yaw = 5.0f * torque;
		}
		
//		Quaternion pitchRotation = Quaternion.AngleAxis(pitch, gameObject.transform.right);
//		Quaternion rollRotation = Quaternion.AngleAxis(-roll, gameObject.transform.forward);
//		
//		gameObject.transform.rotation = pitchRotation * rollRotation * gameObject.transform.rotation;
		
		Vector3 lift = rigidbody.mass * Mathf.Clamp(liftParameter * Vector3.Dot(rigidbody.velocity, rigidbody.transform.forward),
			0.0f, liftAmount) * rigidbody.transform.up;
		
		Vector3 drag = rigidbody.mass * Mathf.Clamp(dragParameter * Vector3.Cross(rigidbody.velocity, rigidbody.transform.forward).magnitude,
			0.0f, dragAmount) * -Vector3.ClampMagnitude(rigidbody.velocity, 1.0f);
		
		rigidbody.AddTorque(rigidbody.transform.right * pitch);
		rigidbody.AddTorque (rigidbody.transform.forward * roll);
		rigidbody.AddTorque (rigidbody.transform.up * yaw);
		rigidbody.AddForce(acceleration + lift + drag);
		Vector3 offset = 10.0f * gameObject.transform.forward;
		offset = Vector3.zero;
		Debug.DrawLine(rigidbody.transform.position + offset, rigidbody.transform.position + offset +
			Vector3.ClampMagnitude(3.0f * acceleration / 10.0f / rigidbody.mass, 3.0f), Color.blue, 2.0f);
		Debug.DrawLine(rigidbody.transform.position + offset, rigidbody.transform.position + offset +
			Vector3.ClampMagnitude(3.0f * lift / liftAmount / rigidbody.mass, 3.0f), Color.yellow, 2.0f);
		Debug.DrawLine(rigidbody.transform.position + offset, rigidbody.transform.position + offset +
			Vector3.ClampMagnitude(rigidbody.velocity / 10.0f, 3.0f), Color.green, 2.0f);
		Debug.DrawLine(rigidbody.transform.position + offset, rigidbody.transform.position + offset +
			Vector3.ClampMagnitude(3.0f * drag / dragAmount, 3.0f), Color.red, 2.0f);
		
//		mainCamera.fieldOfView =
//			Mathf.Clamp(Mathf.Lerp(mainCamera.fieldOfView,
//			60.0f * 25.0f / Vector3.Distance(mainCamera.transform.position, rigidbody.position), 0.2f), 0.1f, 80.0f);
		
		//mainCamera.transform.position += (rigidbody.transform.position - mainCamera.transform.position) * cameraMixRate;
		
//		if (Vector3.Distance(mainCamera.transform.position, rigidbody.transform.position) < minimumCameraDistance) {
//			mainCamera.transform.position = rigidbody.transform.position + minimumCameraDistance * (
//				mainCamera.transform.position - rigidbody.transform.position).normalized;
//		}
		
//		mainCamera.transform.LookAt(gameObject.transform);
	}
	
	void Update() {
		mainCamera.transform.position = gameObject.transform.position - 8.0f * gameObject.transform.forward + 1.0f * gameObject.transform.up;
		mainCamera.transform.rotation = gameObject.transform.rotation;
	}
}
