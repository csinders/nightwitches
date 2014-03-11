using UnityEngine;
using System.Collections;

public class NadyaFirstPersonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
	}
}
