using UnityEngine;
using System.Collections;

public class NadyaFirstPersonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rigidbody.AddForce(100.0f * new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical")));
		rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, 1.0f);
		// transform.Translate(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
	}
}
