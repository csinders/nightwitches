using UnityEngine;
using System.Collections;

public class TriggerText : MonoBehaviour {

	public GameObject Text;


	// Use this for initialization
	void OnTriggerEnter(Collider other) {
		Text.SetActive(true);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
