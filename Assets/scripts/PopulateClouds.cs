using UnityEngine;
using System.Collections;

public class PopulateClouds : MonoBehaviour {
	public GameObject cloud; 

	// Use this for initialization
	void Start () {

		for (var i = 0; i<50; i++){
			var newCloud = Object.Instantiate(cloud) as GameObject;

			newCloud.transform.position = new Vector2(Random.Range(-20,20),Random.Range(10,60));
			newCloud.transform.localScale = new Vector3(Random.Range(1,2), Random.Range(1,2),1);
		}

	
	}
	
}
